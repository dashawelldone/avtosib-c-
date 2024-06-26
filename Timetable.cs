//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.Storage;
//using Newtonsoft.Json;
//using Avtosib;

//namespace Avtosib
//{
//    class Timetables
//    {
//        //public int Id { get; set; }
//        //public string NumberBus { get; set; }
//        //public string Busstop { get; set; }
//        ////public string Time { get; set; }

//    }
//}

//class Timetable
//{
//    public async static Task<ObservableCollection<Timetables>> GetAll()
//    {
//        var localFolder = ApplicationData.Current.LocalFolder;

//        try
//        {
//            var file = await localFolder.GetFileAsync("timetable.json");
//            var text = await FileIO.ReadTextAsync(file);
//            var obscollection = JsonConvert.DeserializeObject<ObservableCollection<Timetables>>(text);
//            return obscollection;
//        }

//        catch (Exception)
//        {
//            return new ObservableCollection<Timetables>();
//        }
//    }


//    public static async Task Edite(Timetables timetables)
//    {
//        var timetableall = await GetAll();
//        var localFolder = ApplicationData.Current.LocalFolder;

//        Timetables timetablefile = null;

//        foreach (var timetables1 in timetableall)
//        {
//            if (timetables1.Id == timetables.Id)
//            {
//                timetablefile = timetables1;
//                break;
//            }

//        }

//        if (timetablefile != null)
//        {
//            timetablefile.NumberBus = timetables.NumberBus;
//            timetablefile.Busstop = timetables.Busstop;
//            timetablefile.Time = timetables.Time;

//        }

//        else
//        {
//            if (timetableall.Count == 0)
//            {
//                timetables.Id = 1;
//            }

//            timetables.Id = timetableall.Last().Id;
//            timetableall.Add(timetables);
//        }

//        var text = JsonConvert.SerializeObject(timetableall);
//        var file = await localFolder.GetFileAsync("user.json");
//        await FileIO.WriteTextAsync(file, text);


//    }

//    public static async Task Delete(int id)
//    {
//        var timetableall = await GetAll();
//        foreach (var timetable in timetableall) 
//        {
//         if (timetable.Id == id)
//            {
//                timetableall.Remove(timetable);
//                break;
//            }
//        }
       
//    }
//}


