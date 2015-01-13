using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsFirst.Models.ViewModels
{
    public class BaseViewModel<T, B>
    {
        public List<T> ConvertCollectionToViewModel(IEnumerable<B> list)
        {
            List<T> viewmodel = new List<T>();
            foreach (var item in list)
            {
               viewmodel.Add((T)Activator.CreateInstance(typeof(T), item));
            }
            return viewmodel;
        }
    }
}