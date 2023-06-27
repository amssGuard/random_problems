import java.util.*;
public class hadamard {
    boolean [][]H;
    int N;
    hadamard(int n){
        H = new boolean[n][n];
        N = n;
    }

    void createHadamard(){
        H[0][0]=true;
        for(int n=1;n<N;n+=n){
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    H[i+n][j]=H[i][j];
                    H[i][j+n]=H[i][j];
                    H[i+n][j+n]=!H[i][j];
                }
            }
        }
    }

    void print(){
        for(int i=0;i<N;i++){
            for(int j=0;j<N;j++){
                if(H[i][j]) System.out.print("T");
                else System.out.print("F");
            }
            System.out.println();
        }
    }

    public static void main(String [] args){
        Scanner in = new Scanner(System.in);
        System.out.println("Enter value of N(must be a power of 2):");
        int N = in.nextInt();
        hadamard mat = new hadamard(N);
        mat.createHadamard();
        mat.print();
    }
}
