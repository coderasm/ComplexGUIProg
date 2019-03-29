using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexGUIProg
{
  class ComplexModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    double _realPartOne = 0;
    double _realPartTwo = 0;
    double _imgPartOne = 0;
    double _imgPartTwo = 0;
    double _realPartThree = 0;
    double _imgPartThree = 0;
    double _power = 0;
    string _polarOne = "";
    string _polarTwo = "";
    string _polarThree = "";
    string _powerResult = "";
    OpsResult _operationsResult = new OpsResult();

    public double RealPartOne
    {
      get
      {
        return _realPartOne;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _realPartOne = result;
      }
    }

    public double RealPartTwo
    {
      get
      {
        return _realPartTwo;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _realPartTwo = result;
      }
    }

    public double ImgPartOne
    {
      get
      {
        return _imgPartOne;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _imgPartOne = result;
      }
    }

    public double ImgPartTwo
    {
      get
      {
        return _imgPartTwo;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _imgPartTwo = result;
      }
    }

    public double RealPartThree
    {
      get
      {
        return _realPartThree;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _realPartThree = result;
      }
    }

    public double ImgPartThree
    {
      get
      {
        return _imgPartThree;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _imgPartThree = result;
      }
    }

    public double Power
    {
      get
      {
        return _power;
      }
      set
      {
        double result = 0;
        if (double.TryParse(value.ToString(), out result))
          _power = result;
      }
    }

    public OpsResult OperationsResult
    {
      get
      {
        return _operationsResult;
      }
      set
      {
        _operationsResult = value;
        RaisePropertyChanged("OperationsResult");
      }
    }

    public string PolarOne
    {
      get
      {
        return _polarOne;
      }
      set
      {
        if (_polarOne != value)
        {
          _polarOne = value;
          RaisePropertyChanged("PolarOne");
        }
      }
    }

    public string PolarTwo
    {
      get
      {
        return _polarTwo;
      }
      set
      {
        if (_polarTwo != value)
        {
          _polarTwo = value;
          RaisePropertyChanged("PolarTwo");
        }
      }
    }

    public string PowerResult
    {
      get
      {
        return _powerResult;
      }
      set
      {
        if (_powerResult != value)
        {
          _powerResult = value;
          RaisePropertyChanged("PowerResult");
        }
      }
    }


    public ComplexModel()
    {
    }

    public void EvaluateOperations()
    {
      var complexOne = new Complex(RealPartOne, ImgPartOne);
      var complexTwo = new Complex(RealPartTwo, ImgPartTwo);
      var operationsResult = new OpsResult();
      operationsResult.Sum = complexOne.add(complexTwo).ToString();
      operationsResult.Diff = complexOne.sub(complexTwo).ToString();
      operationsResult.Prod = complexOne.mul(complexTwo).ToString();
      operationsResult.Div = complexOne.div(complexTwo).ToString();
      OperationsResult = operationsResult;
      PolarOne = complexOne.ToPolarString();
      PolarTwo = complexTwo.ToPolarString();
    }

    public void EvaluatePower()
    {
      var complex = new Complex(RealPartThree, ImgPartThree);
      PowerResult = complex.toPow(Power).ToString();
    }

    private void RaisePropertyChanged(string propertyName)
    {
      // take a copy to prevent thread issues
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class OpsResult
    {
      public string Sum { get; set; } = "";
      public string Diff { get; set; } = "";
      public string Prod { get; set; } = "";
      public string Div { get; set; } = "";
    }
  }
}