//K1-1
//δ

#include <stdio.h>

int main(void)
{
	int n=1;
	double a=1,r,S=0.0,x=1.0;//a:Ar:φδ S:δΜa 
	double temp_S=99999;//δrpΟϊlΝKΙε«’l

//eξρΜόΝ
	printf("φδr=");
	scanf("%lf",&r);
	printf("\n");//όs
	while(1)
	{
		S = S + a*x;
		x = x * r;
		if(temp_S==S){break;}
		n++;
		temp_S=S;
	}
	
	printf("\n");//όs

//Κ\¦
	printf("δΜa:%.10f\n%d\n",S,n);
	return 0;
}
