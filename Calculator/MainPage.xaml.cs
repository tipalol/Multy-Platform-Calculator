using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Button Plus, Minus, Devide, Multiply, Enter;

        Button[] KeyPad;

        public MainPage()
        {
            InitializeComponent();

            //Operation buttons
            Plus = new Button() { Text = "Plus" };
            Minus = new Button() { Text = "Minus" };
            Devide = new Button() { Text = "Devide" };
            Multiply = new Button() { Text = "Multiply" };
            Enter = new Button() { Text = "Enter" };

            Plus.Pressed += Plus_Pressed;
            Minus.Pressed += Minus_Pressed;
            Devide.Pressed += Devide_Pressed;
            Multiply.Pressed += Multiply_Pressed;
            Enter.Pressed += Enter_Pressed;

            //Keypad buttons
            KeyPad = new Button[10];
            for (uint index = 0; index < KeyPad.Count(); ++index)
            {
                ref var button = ref KeyPad[index];
                button = new Button() { Text = index.ToString() };
                button.Pressed += (o, e) => { KeyPadButton_Pressed(index); };
            }
        }

        #region Keypad buttons
        private void KeyPadButton_Pressed(uint index)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Operation buttons
        //////////////////////////////////////////////////////
        //Operations buttons
        private void Enter_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Multiply_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Devide_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Minus_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Plus_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //////////////////////////////////////////////////////
        #endregion
    }
}
