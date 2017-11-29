using System;
using System.Collections.Generic;
using System.IO;
using FirebaseStroageHardware.helper;
using FirebaseStroageHardware.Model;
using Plugin.Media;

using Xamarin.Forms;

namespace FirebaseStroageHardware.Views
{
    public partial class FileUploadPage : ContentPage
    {

        Stream imgStr;
        public FileUploadPage()
        {
            InitializeComponent();
        }

        async void Image_Clicked(object sender, System.EventArgs e)
        {

          await  CrossMedia.Current.Initialize();

            if (CrossMedia.IsSupported==false)
            {
               await DisplayAlert("hata","desteklenmeyen cihaz","okey");
            }
            else
            {
                var file =await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
                {

                });


                if (file!=null)
                {
                   

                    _img.Source= ImageSource.FromStream(() => file.GetStream());
                    imgStr = file.GetStream();
                }

            }


        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var fire = new FireDB();
            var txt = _ent.Text;
            await fire.SaveUserRequest(imgStr,new User{Name=txt});
        }
    }
}
