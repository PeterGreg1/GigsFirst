using System;
using System.Collections.Generic;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class GenericViewModel<T, TB>
    {
        public List<T> ConvertCollectionToViewModel(IEnumerable<TB> list)
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