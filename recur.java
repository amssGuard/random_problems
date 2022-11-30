import java.io.*;
public class recur{
	public static int recure(int n) {
	if(n>0) {
		System.out.print("\t"+n);
		recure(n-5);
	}
		System.out.print("\t"+n);
	return 0;
	}
	public static void main(String[]args) {
		int n=16;
		recure(n);
		
	}
}
