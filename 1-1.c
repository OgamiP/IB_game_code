//���K1-1
//���䋉��

#include <stdio.h>

int main(void)
{
	int n=1;
	double a=1,r,S=0.0,x=1.0;//a:�����Ar:���� S:���䋉���̘a 
	double temp_S=99999;//��r�p�ϐ������l�͓K���ɑ傫���l

//�e���̓���
	printf("����r=");
	scanf("%lf",&r);
	printf("\n");//���s
	while(1)
	{
		S = S + a*x;
		x = x * r;
		if(temp_S==S){break;}
		n++;
		temp_S=S;
	}
	
	printf("\n");//���s

//���ʕ\��
	printf("���䋉���̘a:%.10f\n����%d\n",S,n);
	return 0;
}
