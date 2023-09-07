// // See https://aka.ms/new-console-template for more information

// int a = int.Parse(Console.ReadLine()??"0");
// if (a < 0) a = -a;
// for(int i = -a; i <= a; i++){
//     Console.Write(i);
//     Console.Write(", ")
// }

int num = int.Parse(Console.ReadLine()??"0");
int pow = 0;
int n = 0;
bool valid = false;
while(num > 0){
    if((num&1) >0 ) {
        n+=(1<<pow);
        if (n > 99){
            valid = true;
        }
        if (n > 999){
            valid = false;
            break;
        }
    }
    pow++;
    num>>=1;
}

if (valid){
    Console.WriteLine(n%10);
}
else Console.WriteLine("Invalid Number");

