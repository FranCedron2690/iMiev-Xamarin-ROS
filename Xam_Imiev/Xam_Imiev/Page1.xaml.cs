using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_Imiev
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
            this.SizeChanged += ScreenSizeChange;
        }

        private void ScreenSizeChange(object sender, EventArgs e)
        {
            GridGeneralColumn0.Width = (Width / 3) * 2;//Ancho de la columna  1 que ocupa 2/3 de la pantalla
            //GridGeneral1Column1 ocupará por defecto el tercio restante

            //Como no se puede coger el valor de GridGeneral1Row1.Heigth porque tiene asignado el valor *, debo calcular la altura de el Row Dcha con la Height
            //general de la pantalla
            GridDchaRow0.Height = ((Height  / 10) * 9) / 1.5f;
        }

        private async void Title_Button_ClickAsync(object sender, EventArgs args)
        {
            Button btn = (Button)sender;

            switch (btn.ClassId)
            {
                case "waypoints":
                    await Navigation.PushAsync(new Page1());
                    break;
                case "remote":
                    await Navigation.PushAsync(new Remote());
                    break;
            }
        }

            private void Info_Active_Content(object sender, EventArgs args)
        {
            Button btn = (Button)sender;

            switch (btn.ClassId)
            {
                case "actions":
                    Activar_Info_Section(Actions, true);
                    Activar_Info_Section(GPS, false);
                    Activar_Info_Section(IMU, false);
                    break;
                case "gps":
                    Activar_Info_Section(Actions, false);
                    Activar_Info_Section(GPS, true);
                    Activar_Info_Section(IMU, false);
                    break;
                case "imu":
                    Activar_Info_Section(Actions, false);
                    Activar_Info_Section(GPS, false);
                    Activar_Info_Section(IMU, true);
                    break;
            }
        }

        private void Activar_Info_Section(Frame stacklayout, bool valor)
        {
            stacklayout.IsEnabled = valor;
            stacklayout.IsVisible = valor;
        }
    }
}