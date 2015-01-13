using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class GenericViewModel<T, B>
    {
        public List<T> ConvertCollectionToViewModel(IEnumerable<B> list)
        {
            var viewmodel = new List<T>();
            foreach (var item in list)
            {
               viewmodel.Add((T)Activator.CreateInstance(typeof(T), item));
            }
            return viewmodel;
        }
    }
}