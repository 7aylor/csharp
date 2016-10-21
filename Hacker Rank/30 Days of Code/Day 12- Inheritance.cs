class Student : Person{
    private int[] testScores;
    
    //constructor
    public Student(string fName, string lName, int idNum, int[] scores){
        firstName = fName;
        lastName = lName;
        id = idNum;
        testScores = scores;
    }
    
    //calculates grade
    public char calculate(){
        int totalPoints = 0;
        double avg = 0.0;
        
        //total up scores
        for(int i = 0; i < testScores.Length; i++){
            totalPoints += testScores[i];
        }
        
        //get average
        avg = (double)totalPoints / testScores.Length;
        
        //assign grade letter based on average score
        if(avg >= 90.0){
            return 'O';
        }
        else if(avg < 90.0 && avg >= 80.0){
            return 'E';
        }
        else if(avg < 80.0 && avg >= 70.0){
            return 'A';
        }
        else if(avg < 70.0 && avg >= 55.0){
            return 'P';
        }
        else if(avg < 55.0 && avg >= 40.0){
            return 'D';
        }
        else{
            return 'T';
        }
    }
  
}