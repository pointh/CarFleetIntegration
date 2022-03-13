using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIntegration
{
    public class CarErrorEventArgs : EventArgs
    {
        public Guid FromCar { get; set; }
        public int Severity { get; set; }
    }

    public delegate void CarError(CarErrorEventArgs e);

    public class Car
    {
        Random rnd = new Random();

        public Guid id;
        public Car()
        {
            id = Guid.NewGuid();
        }

        public event CarError ErrorJustHappened;

        public void RunInCaseOfError()
        {
            ErrorJustHappened(new CarErrorEventArgs { Severity = rnd.Next(0, 200), FromCar = id });
        }

        // až bude hotová diagnóza, udělej akci podle doporučení
        public void SubscribeToService(Center center)
        {
            center.ServiceActions += ServicingOnAdvice;
        }

        public void ServicingOnAdvice(CarRepareEventArgs e)
        {
            if (e.ForCar == id)
                Debug.WriteLine($"Car: Přijatá oprava pro auto id={e.ForCar} je {e.ServiceAction}");
        }
    }
}
