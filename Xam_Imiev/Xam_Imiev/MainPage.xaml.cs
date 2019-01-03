using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam_Imiev
{
    public partial class MainPage : ContentPage
    {
#if __ANDROID__
        Droid.ROS_Conection DROID_ROS_Conect = new Droid.ROS_Conection();
#endif
#if __IOS__
        iOS.ROS_Conection iOS_ROS_Conect = new iOS.ROS_Conection();
#endif
#if WINDOWS_UWP
        UWP.ROS_Conection UWP_ROS_Conect = new UWP.ROS_Conection();
#endif
        public MainPage()
        {
            InitializeComponent();
        }

        private void ConectarROS(object sender, EventArgs e)
        {
#if __ANDROID__
            DROID_ROS_Conect.Conectar_a_ROS();
#elif __IOS__
            iOS_ROS_Conect.Conectar_a_ROS();
#elif WINDOWS_UWP
            UWP_ROS_Conect.Conectar_a_ROS();
#endif
        }

        private void Subscribir_Nodo(object sender, EventArgs e)
        {
#if __ANDROID__
            DROID_ROS_Conect.Susbscribir_Nodo();
#elif __IOS__
            iOS_ROS_Conect.Susbscribir_Nodo();
#elif WINDOWS_UWP
            UWP_ROS_Conect.Susbscribir_Nodo();
#endif
        }

        private void Publicar_Nodo(object sender, EventArgs e)
        {
#if __ANDROID__
            DROID_ROS_Conect.Publicar_Nodo();
#elif __IOS__
            iOS_ROS_Conect.Publicar_Nodo();
#elif WINDOWS_UWP
            UWP_ROS_Conect.Publicar_Nodo();
#endif
        }

        private void DesconectarROS(object sender, EventArgs e)
        {
#if __ANDROID__
            DROID_ROS_Conect.Desconectar();
#elif __IOS__
            iOS_ROS_Conect.Desconectar();
#elif WINDOWS_UWP
            UWP_ROS_Conect.Desconectar();
#endif
        }
    }


}
