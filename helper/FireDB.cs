using System;
using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;
using Firebase.Xamarin.Database;
using FirebaseStroageHardware.Model;

namespace FirebaseStroageHardware.helper
{
    public class FireDB
    {
        FirebaseClient client;
        public FireDB()
        {
            client = new FirebaseClient("https://hardwareandro-6293a.firebaseio.com/");
          
        }

        public async Task SaveUserRequest( Stream imgStream ,User req)
        {
            var postData =await client.Child("User").PostAsync<User>(req);

            var imgUrl = await new FirebaseStorage("hardwareandro-6293a.appspot.com")
                .Child("HWA")
                .Child(postData.Key)
                .PutAsync(imgStream);



            req.ImageUrl = imgUrl;

            var updateData = client.Child("User/" + postData.Key)
                                   .PutAsync<User>(req);



        }
    }
}
