﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bukva
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        String[] buffer;
        Dictionary<string, string> letterTable;

        public Form1()
        {
            InitializeComponent();
            buffer = new String[3];
            clearBuffer();
            letterTable = new Dictionary<string, string>();

            letterTable.Add("a", "а");
            letterTable.Add("b", "б");
            letterTable.Add("c", "ц");
            letterTable.Add("d", "д");
            letterTable.Add("e", "е");
            letterTable.Add("f", "ф");
            letterTable.Add("g", "г");
            letterTable.Add("h", "х");
            letterTable.Add("i", "и");
            letterTable.Add("j", "й");
            letterTable.Add("k", "к");
            letterTable.Add("l", "л");
            letterTable.Add("m", "м");
            letterTable.Add("n", "н");
            letterTable.Add("o", "о");
            letterTable.Add("p", "п");
            letterTable.Add("q", "я");
            letterTable.Add("r", "р");
            letterTable.Add("s", "с");
            letterTable.Add("t", "т");
            letterTable.Add("u", "у");
            letterTable.Add("v", "в");
            letterTable.Add("w", "щ");
            letterTable.Add("x", "х");
            letterTable.Add("y", "ы");
            letterTable.Add("z", "з");
            letterTable.Add("oemquotes", "ь");
            letterTable.Add("ja", "я");
            letterTable.Add("ya", "я");
            letterTable.Add("je", "э");
            letterTable.Add("shh", "щ");
            letterTable.Add("sch", "щ");
            letterTable.Add("jo", "ё");
            letterTable.Add("yo", "ё");
            letterTable.Add("zh", "ж");
            letterTable.Add("ch", "ч");
            letterTable.Add("sh", "ш");
            letterTable.Add("yu", "ю");
            letterTable.Add("ju", "ю");
            letterTable.Add("ye", "э");
            letterTable.Add("nooemperiod", "№");

            letterTable.Add("A", "А");
            letterTable.Add("B", "Б");
            letterTable.Add("C", "Ц");
            letterTable.Add("D", "Д");
            letterTable.Add("E", "Е");
            letterTable.Add("F", "Ф");
            letterTable.Add("G", "Г");
            letterTable.Add("H", "Х");
            letterTable.Add("I", "И");
            letterTable.Add("J", "Й");
            letterTable.Add("K", "К");
            letterTable.Add("L", "Л");
            letterTable.Add("M", "М");
            letterTable.Add("N", "Н");
            letterTable.Add("O", "О");
            letterTable.Add("P", "П");
            letterTable.Add("Q", "Я");
            letterTable.Add("R", "Р");
            letterTable.Add("S", "С");
            letterTable.Add("T", "Т");
            letterTable.Add("U", "У");
            letterTable.Add("V", "В");
            letterTable.Add("W", "Щ");
            letterTable.Add("X", "Х");
            letterTable.Add("Y", "Ы");
            letterTable.Add("Z", "З");
            letterTable.Add("OEMQUOTES", "Ь");
            letterTable.Add("JA", "Я");
            letterTable.Add("YA", "Я");
            letterTable.Add("JE", "Э");
            letterTable.Add("SHH", "Щ");
            letterTable.Add("SCH", "Щ");
            letterTable.Add("JO", "Ё");
            letterTable.Add("YO", "Ё");
            letterTable.Add("ZH", "Ж");
            letterTable.Add("CH", "Ч");
            letterTable.Add("SH", "Ш");
            letterTable.Add("YU", "Ю");
            letterTable.Add("JU", "Ю");
            letterTable.Add("YE", "Э");
            letterTable.Add("NOOEMPERIOD", "№");
            letterTable.Add("D3", "ъ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepSkyBlue;
            button2.Font = new Font(button2.Font, FontStyle.Regular);
            button2.ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            button1.BackColor = Color.SteelBlue;
            button1.Font = new Font(button1.Font, FontStyle.Bold);
            button1.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            timer1.Start();
            this.Text = "Bukva: ON";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
            button1.Font = new Font(button1.Font, FontStyle.Regular);
            button1.ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            button2.BackColor = Color.SteelBlue;
            button2.Font = new Font(button2.Font, FontStyle.Bold);
            button2.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            timer1.Stop();
            this.Text = "Bukva: OFF";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                if (GetAsyncKeyState(i) == -32767)
                {
                    if (!ModifierKeys.HasFlag(Keys.Control))
                    {
                        string txt;
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            txt = Enum.GetName(typeof(Keys), i).ToUpper();
                        else
                            txt = Enum.GetName(typeof(Keys), i).ToLower();
                        if (txt == "back")
                        {
                            if (letterTable.ContainsKey(buffer[0]) && (letterTable.ContainsKey(buffer[1])) && (letterTable.ContainsKey(buffer[2])) && (buffer[2].Contains(buffer[0] + buffer[1])))
                            {
                                if (letterTable.ContainsKey(buffer[0] + buffer[1]))
                                    SendKeys.SendWait(letterTable[buffer[0] + buffer[1]]);
                                else
                                {
                                    SendKeys.SendWait(letterTable[buffer[0]]);
                                    SendKeys.SendWait(letterTable[buffer[1]]);
                                }
                                SendKeys.SendWait(letterTable[((buffer[2])[2]).ToString()]);
                            }
                            else if ((letterTable.ContainsKey(buffer[1])) && (letterTable.ContainsKey(buffer[2])) && (buffer[2].Contains(buffer[1])) && (buffer[1] != buffer[2]))
                            {
                                SendKeys.SendWait(letterTable[buffer[1]]);
                                SendKeys.SendWait(letterTable[((buffer[2])[1]).ToString()]);
                            }
                        }
                        
                        if (letterTable.ContainsKey(buffer[1] + buffer[2] + txt))
                        {
                            if (!letterTable.ContainsKey(buffer[1] + buffer[2]))
                                SendKeys.SendWait("{BACKSPACE}");
                            SendKeys.SendWait("{BACKSPACE}");
                            txt = buffer[1] + buffer[2] + txt;
                        }
                        else if (letterTable.ContainsKey(buffer[2] + txt))
                        {
                            SendKeys.SendWait("{BACKSPACE}");
                            txt = buffer[2] + txt;
                        }

                        if (letterTable.ContainsKey(txt))
                        {
                            SendKeys.SendWait("{BACKSPACE}");
                            SendKeys.SendWait(letterTable[txt]);
                        }
                        pushShift(txt);
                    }
                }
            }
        }

        void pushShift(string str)
        {
            buffer[0] = buffer[1];
            buffer[1] = buffer[2];
            buffer[2] = str;
        }

        void clearBuffer()
        {
            buffer[0] = "";
            buffer[1] = "";
            buffer[2] = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Width = ClientRectangle.Width / 2;
            this.button1.Height = ClientRectangle.Height;

            this.button2.Location = new Point(ClientRectangle.Width / 2, 0);
            this.button2.Width = ClientRectangle.Width / 2;
            this.button2.Height = ClientRectangle.Height;
        }
    }
}