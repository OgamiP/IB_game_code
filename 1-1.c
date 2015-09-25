//演習1-1
//等比級数

#include <stdio.h>

int main(void)
{
	int n=1;
	double a=1,r,S=0.0,x=1.0;//a:初項、r:公比 S:等比級数の和 
	double temp_S=99999;//比較用変数初期値は適当に大きい値

//各情報の入力
	printf("公比r=");
	scanf("%lf",&r);
	printf("\n");//改行
	while(1)
	{
		S = S + a*x;
		x = x * r;
		if(temp_S==S){break;}
		n++;
		temp_S=S;
	}
	
	printf("\n");//改行

//結果表示
	printf("等比級数の和:%.10f\n項数%d\n",S,n);
	return 0;
}
