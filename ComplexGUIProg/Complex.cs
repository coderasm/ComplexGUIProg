using System; // namespace containing ArgumentOutOfRangeException

public class Complex
{
  private double rP = 0; // real part
  private double iP = 0; // imaginary part
  private double polarMagnitude = 0;
  private double polarAngle = 0;
  //tracks if the complex object is undefined
  private bool isUndefined = false;

  public Complex()
  {

  }

  //initializing constructor
  public Complex(double r, double i)
  {
    SetComplex(r, i);
  }

  //represents a null/undefined complex object.
  //allows a null/undefined complex object to
  //to behave as a defined/non-null complex object.
  public Complex(object nullObject)
  {
    //If we pass in null, mark the object as undefined
    if (nullObject == null)
      isUndefined = true;
  }

  public void SetComplex(double r, double i)
  {
    rP = r;
    iP = i;
    polarMagnitude = (double)(int)(1000 * Math.Sqrt(rP * rP + iP * iP))/1000;
    if (rP == 0 && iP > 0)
      polarAngle = Math.PI / 2;
    else if (rP == 0 && iP < 0)
      polarAngle = -Math.PI / 2;
    else if (rP == 0 && iP == 0)
      polarAngle = 0;
    else
      polarAngle = Math.Atan(iP / rP);
  }

  public static Complex[] SquareRootsOfi()
  {
    // z = a + bi
    // i = z^2 = (a^2 - b^2) + 2abi
    // i = re^(i*pi*theta)
    //i^(1/2) = (re^(i*pi*theta))^1/2 = r^(1/2) * (e^(i*pi*(theta/2))) = r^(1/2) * (-1^(theta/2))
    var deg = 90;
    var magnitude = 1;
    var newDeg = (deg / 2) * (Math.PI / 180);
    var newMagnitude = Math.Sqrt(magnitude);
    var rootOne = new Complex(newMagnitude * Math.Cos(newDeg), newMagnitude * Math.Sin(newDeg));
    var rootTwo = new Complex(-newMagnitude * Math.Cos(newDeg), -newMagnitude * Math.Sin(newDeg));
    return new Complex[] { rootOne, rootTwo };
  }

  public Complex toPow(double power)
  {
    var realPart = Math.Pow(polarMagnitude, power) * Math.Cos(power * polarAngle);
    var imaginaryPart = Math.Pow(polarMagnitude, power) * Math.Sin(power * polarAngle);
    return new Complex(Math.Round(realPart), Math.Round(imaginaryPart));
  }

  public Complex add(Complex c1)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (isUndefined || c1.isUndefined)
      return new Complex(null);
    var realPart = rP + c1.rP;
    var imaginaryPart = iP + c1.iP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public static Complex addTwo(Complex c1, Complex c2)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (c1.isUndefined || c2.isUndefined)
      return new Complex(null);
    var realPart = c1.rP + c2.rP;
    var imaginaryPart = c1.iP + c2.iP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public Complex sub(Complex c1)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (isUndefined || c1.isUndefined)
      return new Complex(null);
    var realPart = rP - c1.rP;
    var imaginaryPart = iP - c1.iP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public static Complex subTwo(Complex c1, Complex c2)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (c1.isUndefined || c2.isUndefined)
      return new Complex(null);
    var realPart = c1.rP - c2.rP;
    var imaginaryPart = c1.iP - c2.iP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public Complex mul(Complex c1)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (isUndefined || c1.isUndefined)
      return new Complex(null);
    // use the formula (a+bj) * (c+dj) = (ac-bd) + (ad+bc)j
    var realPart = rP * c1.rP - iP * c1.iP;
    var imaginaryPart = rP * c1.iP + iP * c1.rP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public static Complex mulTwo(Complex c1, Complex c2)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (c1.isUndefined || c2.isUndefined)
      return new Complex(null);
    // use the formula (a+bj) * (c+dj) = (ac-bd) + (ad+bc)j
    var realPart = c1.rP * c2.rP - c1.iP * c2.iP;
    var imaginaryPart = c1.rP * c2.iP + c1.iP * c2.rP;
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex(realPart, imaginaryPart);
  }

  public Complex div(Complex c1)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (isUndefined || c1.isUndefined || isZero(c1))
      return new Complex(null);
    // use the formula (a+bj) / (c+dj) = (1/(c^2 + d^2)) * (ac+bd) + (1/(c^2 + d^2)) * (bc - ad)j
    var realPart = (int)(1000 * (1 / (c1.rP * c1.rP + c1.iP * c1.iP)) * (rP * c1.rP + iP * c1.iP));
    var imaginaryPart = (int)(1000 * (1 / (c1.rP * c1.rP + c1.iP * c1.iP)) * (iP * c1.rP - rP * c1.iP));
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex((double)realPart / 1000, (double)imaginaryPart / 1000);
  }

  public static Complex divTwo(Complex c1, Complex c2)
  {
    //check if this complex number or the other complex number is undefined
    //if either are undefined, then return an undefined complex number
    if (c1.isUndefined || c2.isUndefined || isZero(c2))
      return new Complex(null);
    // use the formula (a+bj) / (c+dj) = (1/(c^2 + d^2)) * (ac+bd) + (1/(c^2 + d^2)) * (bc - ad)j
    var realPart = (int)(1000 * (1 / (c2.rP * c2.rP + c2.iP * c2.iP)) * (c1.rP * c2.rP + c1.iP * c2.iP));
    var imaginaryPart = (int)(1000 * (1 / (c2.rP * c2.rP + c2.iP * c2.iP)) * (c1.iP * c2.rP - c1.rP * c2.iP));
    //return a new complex number to prevent mutation of other two complex numbers
    return new Complex((double)(realPart) /1000, (double)(imaginaryPart) / 1000);
  }

  private static bool isZero(Complex c)
  {
    return c.rP == 0 && c.iP == 0;
  }

  public Complex print()
  {
    Console.WriteLine(ToString());
    return this;
  }

  public override string ToString()
  {
    if (isUndefined)
      return "Undefined";
    return $"{rP} + {iP}j";
  }

  public Complex printPolar()
  {
    Console.WriteLine(ToPolarString());
    return this;
  }

  public string ToPolarString()
  {
    if (isUndefined)
      return "Undefined";
    var finalAngle = (double)(int)(1000 * (polarAngle * (180 / Math.PI))) / 1000;
    return polarMagnitude + "e^(j" + finalAngle + ")";
  }

}


