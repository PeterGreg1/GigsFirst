using System;
using System.Collections.Generic;

namespace GigsFirst.Models.ViewModels
{
    public class BaseViewModel<T, TB>
    {
        public List<T> ConvertCollectionToViewModel(IEnumerable<TB> list)
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