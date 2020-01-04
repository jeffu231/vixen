﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NLog;
using VixenModules.Media.Audio;
using System.ComponentModel;
using System.Threading.Tasks;
using Common.Controls.TimelineControl;
using Common.Controls.TimelineControl.LabeledMarks;
using VixenModules.App.Marks;
using VixenModules.Media.Audio.SampleProviders;
using Font = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace Common.Controls.Timeline
{
	/// <summary>
	/// Waveform visualizer class
	/// </summary>
	[System.ComponentModel.DesignerCategory("")] // Prevent this from showing up in designer.
	public sealed class Waveform : TimelineControlBase
	{
		private double samplesPerPixel;
		private List<Sample> samples;
		private Audio audio;
		private BackgroundWorker bw;
		private bool _creatingSamples = false;
		private bool _showMarkAlignment;
		private IEnumerable<TimeSpan> _activeTimes;
		
		private readonly TimeLineGlobalEventManager _timeLineGlobalEventManager;

		/// <summary>
		/// Creates a waveform view of the <code>Audio</code> that is associated scaled to the timeinfo.
		/// </summary>
		/// <param name="timeinfo"></param>
		public Waveform(TimeInfo timeinfo)
			: base(timeinfo)
		{
			samples = new List<Sample>();
			BackColor = Color.Gray;
			Visible = false;
			_timeLineGlobalEventManager = TimeLineGlobalEventManager.Manager;
			_timeLineGlobalEventManager.AlignmentActivity += WaveFormSelectedTimeLineGlobalMove;
			_timeLineGlobalEventManager.CursorMoved += CursorMoved;
		}

		private void CursorMoved(object sender, TimeSpanEventArgs e)
		{
			Invalidate();
		}

		private void WaveFormSelectedTimeLineGlobalMove(object sender, AlignmentEventArgs e)
		{
			_showMarkAlignment = e.Active;
			_activeTimes = e.Times;
			Refresh();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			//Adjusts WaveForm Height with a minimum of 40 pixels
			if (e.Button == MouseButtons.Left & Cursor == Cursors.HSplit & e.Location.Y > 40)
			{
				Height = e.Location.Y + 1;
			}
			else
			{
				Cursor = e.Location.Y <= Height - 1 && e.Location.Y >= Height - 6 ? Cursors.HSplit : Cursors.Hand;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			//Resets WaveForm Height to default value of 50 when you double click the HSplit
			if (Cursor == Cursors.HSplit)
			{
				Height = 50;
			}
		}

		//private void CreateWorker()
		//{
		//	if (bw != null) {
		//		bw.DoWork -= new DoWorkEventHandler(bw_createScaleSamples);
		//		bw.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
		//	}
		//	bw = new BackgroundWorker();
		//	bw.WorkerSupportsCancellation = true;
		//	bw.DoWork += new DoWorkEventHandler(bw_createScaleSamples);
		//	bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
		//}

		//Create samples to scale based on the current timeline ticks period.
		//Runs in background to keep the ui free.
		private void CreateSamples()
		{
			_creatingSamples = true;
			
			if (audio == null)
			{
				_creatingSamples = false;
				return;
			}
			if (!audio.MediaLoaded) {
				audio.LoadMedia(TimeSpan.Zero);
			}

			var totalPixels = timeToPixels(audio.MediaDuration);
			samplesPerPixel = audio.NumberSamples / totalPixels;
			samples = audio.GetSamples((int) samplesPerPixel);
			_creatingSamples = false;

			if (InvokeRequired)
			{
				BeginInvoke((Action)FinishedSamples);
			}
		}

		private void FinishedSamples()
		{
			//invalidate the control after the samples are created
			Invalidate();
		}

		/// <summary>
		/// sets the associated audio module to produce a waveform on
		/// </summary>
		public Audio Audio
		{
			set { SetAudio(value); }

			get { return audio; }
		}

		private delegate void SetAudioDelegate(VixenModules.Media.Audio.Audio value);

		private void SetAudio(VixenModules.Media.Audio.Audio value)
		{
			if (this.InvokeRequired)
				this.Invoke(new SetAudioDelegate(SetAudio), value);
			else {
				//Clean up any existing audio. 
				if (audio != null) {
					audio.Dispose();
				}
				audio = value;
				if (audio != null)
				{
					Task.Factory.StartNew(CreateSamples);
					Visible = true;
					// Make us visible if we have audio to display.
				}
				else {
					Visible = false;
				}

				this.Invalidate();
			}
		}

		protected override Size DefaultSize
		{
			get { return new Size(400, 50); }
		}

		protected override void OnTimePerPixelChanged(object sender, EventArgs e)
		{
			while (_creatingSamples)
			{
				Thread.Sleep(1);
			}
			Task.Factory.StartNew(CreateSamples);
		}

		protected override void OnPlaybackStartTimeChanged(object sender, EventArgs e)
		{
			//Do nothing
		}

		protected override void OnPlaybackEndTimeChanged(object sender, EventArgs e)
		{
			//Do nothing
		}

		protected override void OnPlaybackCurrentTimeChanged(object sender, EventArgs e)
		{
			//Do nothing
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (VisibleTimeStart <= audio.MediaDuration)
			{
				if (samples.Count > 0 && !_creatingSamples)
				{
					//Draws the Mark alignment through the waveform if active mark is being moved.
					if (_showMarkAlignment)
					{
						Pen p;
						p = new Pen(Brushes.Yellow) { DashPattern = new float[] { 2, 2 } };

						foreach (var activeTime in _activeTimes)
						{
							var x1 = timeToPixels(activeTime - VisibleTimeStart);
							e.Graphics.DrawLine(p, x1, 0, x1, Height);
						}
							
						p.Dispose();
					}

					

					//Draws Waveform
					e.Graphics.TranslateTransform(-timeToPixels(VisibleTimeStart), 0);
					float maxSample = 1;
					int workingHeight = Height - (int) (Height*.1); //Leave a little margin
					float factor = workingHeight/maxSample;

					float maxValue = 2*maxSample*factor;
					float minValue = -maxSample*factor;
					int start = (int) timeToPixels(VisibleTimeStart);
					int end = (int) timeToPixels(VisibleTimeEnd <= audio.MediaDuration ? VisibleTimeEnd : audio.MediaDuration);
					
					for (int x = start; x < end; x += 1)
					{
						if (samples.Count <= x) break;
						{
							float lowPercent = (((samples[x].Low*factor) - minValue)/maxValue);
							float highPercent = (((samples[x].High*factor) - minValue)/maxValue);
							e.Graphics.DrawLine(Pens.Black, x, workingHeight*lowPercent, x, workingHeight*highPercent);
						}
					}

					DrawCursor(e.Graphics);
				}
				else
				{
					using (Font f = new Font(Font.FontFamily, 10f, FontStyle.Regular))
					{
						e.Graphics.DrawString("Building waveform.....", f, Brushes.Black,
							new Point((int)timeToPixels(VisibleTimeStart) + 15,
								(int)(Height - f.GetHeight(e.Graphics)) / 2),
							new StringFormat { Alignment = StringAlignment.Near });
					}
				}
			}

			base.OnPaint(e);
		}

		private void DrawCursor(Graphics g)
		{
			using (Pen p = new Pen(Color.Blue, 1))
			{
				var curPos = timeToPixels(TimeLineGlobalStateManager.Manager.CursorPosition);
				g.DrawLine(p, curPos, 0, curPos, Height);
			}
		}
	}
}