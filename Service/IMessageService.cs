using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSample.Service
{
    public interface IMessageService
    {
        void ShowDialog(string message);
        MessageBoxResult Question(string message);
    }
}
