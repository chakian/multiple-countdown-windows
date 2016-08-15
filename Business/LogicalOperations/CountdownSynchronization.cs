using Business.DataOperations;
using Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.LogicalOperations
{
    public static class CountdownSynchronization
    {
        public static List<CountdownStructure> Synchronize(List<CountdownStructure> listOnScreen, int loggedInUser)
        {
            List<CountdownStructure> newListForScreen;

            CountdownData cdata = new CountdownData();
            List<CountdownStructure> ListInDB = cdata.GetCountdownsOfUser(loggedInUser).ToList();
            List<CountdownStructure> ListOnScreen = listOnScreen.ToList();

            RemoveEqualEntriesFromLists(ListOnScreen, ListInDB, out newListForScreen);
            
            //TODO: There is a bug too: https://github.com/chakian/multiple-countdown-windows/issues/11
            var itemsNotOnScreen = getItemsThatDontExistOnScreen(ListOnScreen, ListInDB);
            var itemsNotInDB = getItemsThatDontExistInDB(ListInDB, ListOnScreen);
            var itemsNotUpToDateOnScreen = getItemsThatAreOutdatedOnScreen(ListOnScreen, ListInDB);
            var itemsNotUpToDateInDB = getItemsThatAreOutdatedInDB(ListInDB, ListOnScreen);

            //insert countdowns that didn't exist in db into database
            foreach (var item in itemsNotInDB)
            {
                cdata.InsertCountdown(item);
                newListForScreen.Add(item);
            }
            //update countdowns
            foreach (var item in itemsNotUpToDateInDB)
            {
                cdata.UpdateCountdown(item);
            }

            if(itemsNotOnScreen != null && itemsNotOnScreen.Count > 0)
            {
                newListForScreen.AddRange(itemsNotOnScreen);
            }

            if (itemsNotUpToDateOnScreen != null && itemsNotUpToDateOnScreen.Count > 0)
            {
                newListForScreen.AddRange(itemsNotUpToDateOnScreen);
            }

            return newListForScreen;
        }

        static void RemoveEqualEntriesFromLists(List<CountdownStructure> ListOnScreen, List<CountdownStructure> ListInDB, out List<CountdownStructure> newListForScreen)
        {
            newListForScreen = new List<CountdownStructure>();
            var tempScreen = ListOnScreen.ToList();
            var tempDB = ListInDB.ToList();

            foreach (var screenItem in tempScreen.ToList())
            {
                if (tempDB.Any(q => screenItem.Compare(q) == CountdownStructure.EqualityStatus.Equal))
                {
                    newListForScreen.Add(screenItem);

                    ListOnScreen.RemoveAll(q => q.CountdownGuid == screenItem.CountdownGuid);
                    ListInDB.RemoveAll(q => q.CountdownGuid == screenItem.CountdownGuid);
                }
            }
            foreach (var item in tempDB.ToList())
            {
                if (tempScreen.Any(q => item.Compare(q) == CountdownStructure.EqualityStatus.Equal))
                {
                    ListInDB.Remove(item);
                }
            }
        }

        static List<CountdownStructure> getItemsThatAreOutdatedOnScreen(List<CountdownStructure> screen, List<CountdownStructure> db)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var dbItem in db)
            {
                if (screen.Any(screenItem => screenItem.Compare(dbItem) == CountdownStructure.EqualityStatus.SecondIsNew))
                {
                    result.Add(dbItem);
                }
            }
            return result;
        }
        static List<CountdownStructure> getItemsThatDontExistOnScreen(List<CountdownStructure> screen, List<CountdownStructure> db)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var dbItem in db)
            {
                if (screen.Any(screenItem => screenItem.Title == dbItem.Title && screenItem.CountdownGuid == dbItem.CountdownGuid) == false)
                {
                    result.Add(dbItem);
                }
            }
            return result;
        }

        static List<CountdownStructure> getItemsThatAreOutdatedInDB(List<CountdownStructure> db, List<CountdownStructure> screen)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var screenItem in screen)
            {
                if (db.Any(dbItem => dbItem.Compare(screenItem) == CountdownStructure.EqualityStatus.SecondIsNew))
                {
                    result.Add(screenItem);
                }
            }
            return result;
        }
        static List<CountdownStructure> getItemsThatDontExistInDB(List<CountdownStructure> db, List<CountdownStructure> screen)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var screenItem in screen)
            {
                if (db.Any(dbItem => dbItem.Title == screenItem.Title && dbItem.CountdownGuid == screenItem.CountdownGuid) == false)
                {
                    result.Add(screenItem);
                }
            }
            return result;
        }
    }
}
