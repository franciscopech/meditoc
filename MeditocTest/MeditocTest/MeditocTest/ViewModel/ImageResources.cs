using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditocTest.ViewModel
{
    [ContentProperty(nameof(Source))]
    class ImageResourcesExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var img = Source != null ? ImageSource.FromResource(Source, typeof(ImageResourcesExtension).GetTypeInfo().Assembly) : null;
            return img;
        }
    }
}