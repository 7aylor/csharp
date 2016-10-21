	// Add your code here

    public Difference(int[] arr){
        elements = arr;
    }

    public void computeDifference(){
        int max = int.MinValue;
        int min = int.MaxValue;
        for(int i = 0; i < this.elements.Length; i++){
            for(int j = i; j < this.elements.Length; j++){
                if(this.elements[i] > max){
                    max = this.elements[i];
                }
                if(this.elements[i] < min){
                    min = this.elements[i];
                }
            }
        }
        
        maximumDifference = max - min;
    }