using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.IO;

public class GameOfLife
{

    public class Grid
    {
        public int gridLength;
        public Cell[,] currGridArr;
        public Cell[,] nextGridArr;
        List<Cell[,]> frames = new List<Cell[,]>();

        //constructor
        public Grid()
        {
            int buildGridChoice;
            gridLength = 10;

            Console.ForegroundColor = ConsoleColor.White;

            string welcome = "Welcome to Conway's Game of Life!";
            Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(welcome);

            loadGrid("pulsar.xml");
            
            printGrid(currGridArr, 3);

            string cont = "\n\n\nPress any key to get started...";
            Console.WriteLine(cont);
            Console.ReadKey();
            Console.Clear();

            frames.Clear();

            Console.WriteLine("Options:");
            Console.WriteLine("1) Build Grid");
            Console.WriteLine("2) Load Grid");
            Console.WriteLine("3) Random Grid");
            Console.Write(">");
            try
            {
                buildGridChoice = Convert.ToInt32(Console.ReadLine());

                if (buildGridChoice == 1)
                {
                    getGridLength(ref gridLength);
                    buildGrid(gridLength);
                }
                else if (buildGridChoice == 2)
                {
                    Console.Write("What is the file name(ex. block.xml)? ");
                    string fileName = Console.ReadLine();
                    loadGrid(fileName);
                }
                else if (buildGridChoice == 3)
                {
                    Random rand = new Random();
                    gridLength = rand.Next(3, 22);
                    initRandGrid(ref currGridArr);
                    frames.Add(currGridArr);
                }
                else
                {
                    Console.WriteLine("Incorrect choice, creating random grid.");
                    throw new Exception(); 
                }
            }
            catch
            {
                Random rand = new Random();
                gridLength = rand.Next(3, 22);
                initRandGrid(ref currGridArr);
                frames.Add(currGridArr);
            }
            
            initDeadGrid(ref nextGridArr);
        }

        private int GridLength
        {
            get
            {
                return gridLength;
            }
            set
            {
                gridLength = value;
            }
        }
        private Cell[,] GridArr
        {
            get
            {
                return currGridArr;
            }
            set
            {
                currGridArr = value;
            }
        }
        private Cell[,] NextGridArr
        {
            get
            {
                return nextGridArr;
            }
            set
            {
                nextGridArr = value;
            }
        }
        private List<Cell[,]> Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        //ask the user how long the grid should be
        private void getGridLength(ref int length)
        {
            Console.Write("How long should our grid be?");
            try
            {
                length = Convert.ToInt32(Console.ReadLine());
                if (length <= 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Error: This value must be an integer greater than 1. Default length is 10");
            }
        }

        //build grid by coordinates
        private void buildGrid(int length)
        {
            this.initDeadGrid(ref this.currGridArr);
            this.frames.Add(currGridArr);
            List<int> ints = new List<int>();
            int input1 = 1;
            int input2 = 1;

            while(input1 != -1 && input2 != -1)
            {
                Console.Clear();
                this.printGrid(this.currGridArr);
                Console.WriteLine("Type two numbers that are between 0 and {0} for the x and y coordinates, or type -1 to exit building mode, or -2 to delete previous life", length-1);
                Console.Write("X Coordinate: ");

                string coordinateX = Console.ReadLine();
                while(coordinateX == "" || Convert.ToInt32(coordinateX) > length-1 ||
                    (Convert.ToInt32(coordinateX) < 0 && Convert.ToInt32(coordinateX) != -1 && Convert.ToInt32(coordinateX) != -2))
                {
                    Console.Write("Please type an integer between 0 and {0}, or -1 to exit build mode: ", length - 1);
                    coordinateX = Console.ReadLine();
                }
                input1 = Convert.ToInt32(coordinateX);

                if (input1 == -1)
                {
                    break;
                }
                else if (input1 == -2)
                {
                    if(ints.Count == 0)
                    {
                        Console.WriteLine("Cannot delete from blank grid.");
                        Console.ReadKey();
                    }
                    else
                    {
                        this.removeLifeFromCell(ints[ints.Count - 2], ints[ints.Count - 1]);
                        ints.RemoveAt(ints.Count - 2);
                        ints.RemoveAt(ints.Count - 1);
                    }
                }
                else
                {
                    Console.Write("Y Coordinate: ");
                    string coordinateY = Console.ReadLine();
                    while (coordinateY == "" || Convert.ToInt32(coordinateY) > length - 1 ||
                        (Convert.ToInt32(coordinateY) < 0 && Convert.ToInt32(coordinateY) != -1 && Convert.ToInt32(coordinateY) != -2))
                    {
                        Console.Write("Please type an integer between 0 and {0}, or -1 to exit build mode: ", length - 1);
                        coordinateY = Console.ReadLine();
                    }
                    input2 = Convert.ToInt32(coordinateY);

                    if (input2 == -1)
                    {
                        break;
                    }
                    if (input2 == -2)
                    {
                        if (ints.Count == 0)
                        {
                            Console.WriteLine("Cannot delete from blank grid.");
                            Console.ReadKey();
                        }
                        else
                        {
                            this.removeLifeFromCell(ints[ints.Count - 2], ints[ints.Count - 1]);
                            ints.RemoveAt(ints.Count - 2);
                            ints.RemoveAt(ints.Count - 1);
                        }
                    }
                }

                if (input1 != -1 && input2 != -1 && input1 != -2 && input2 != -2)
                {
                    this.addLifeToCell(input1, input2);
                    ints.Add(input1);
                    ints.Add(input2);
                }
            }

            Console.WriteLine("Finished building grid");

            Console.WriteLine("Save grid? (1 for yes, any character for no)");

            int save = 0;

            try
            {
                save = Convert.ToInt32(Console.ReadLine());
                if(save == 1)
                {
                    Console.Write("Filename: ");
                    string fileName = Console.ReadLine();
                    this.saveGrid(fileName);
                    Console.WriteLine("Grid saved");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Grid not saved");
            }
        }

        //saves xml file to current directory of exe
        private void saveGrid(string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("grid");
                writer.WriteElementString("gridLength", this.gridLength.ToString());
                writer.WriteStartElement("currGridArr");

                for (int i = 0; i < gridLength; i++)
                {
                    for (int j = 0; j < gridLength; j++)
                    {
                        if (this.currGridArr[i, j].Alive == true)
                        {
                            writer.WriteStartElement("Alive");
                            writer.WriteElementString("IndexX", this.currGridArr[i, j].IndexX.ToString());
                            writer.WriteElementString("IndexY", this.currGridArr[i, j].IndexY.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }


                writer.WriteEndElement();
                writer.WriteEndDocument();
                
            }
        }

        //loads from xml file saved in same directory as exe
        private void loadGrid(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(fileName);

                int xVal = 0;
                int yVal = 0;

                foreach (XmlElement x in doc.DocumentElement.ChildNodes)
                {
                    //Console.WriteLine("Name: " + x.Name + " doc ChildNodes: " + doc.DocumentElement.ChildNodes.Count);
                    if (x.Name == "gridLength")
                    {
                        //Console.WriteLine("gridLength: " + x.InnerText);
                        gridLength = Convert.ToInt32(x.InnerText);
                        initDeadGrid(ref currGridArr);
                        frames.Add(currGridArr);
                    }
                    if(x.Name == "currGridArr")
                    {
                        foreach(XmlElement y in x.ChildNodes)
                        {
                            if (y.Name == "Alive") ;
                            {
                                //Console.WriteLine("Y Name: " + y.Name);
                                foreach (XmlElement z in y.ChildNodes)
                                {
                                    if (z.Name == "IndexX")
                                    {
                                        xVal = Convert.ToInt32(z.InnerText);
                                        //Console.WriteLine("Z Name: " + z.Name + " Value: " + xVal);
                                    }
                                    if (z.Name == "IndexY")
                                    {
                                        yVal = Convert.ToInt32(z.InnerText);
                                        //Console.WriteLine("Name: " + z.Name + " Value: " + yVal + " Y Nodes: " + y.ChildNodes.Count);
                                        addLifeToCell(xVal, yVal);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                frames.RemoveAt(frames.Count - 1);
                Console.WriteLine("Load Failed, using Random Grid");
                initRandGrid(ref this.currGridArr);
                frames.Add(currGridArr);
            }
        }

        //initialize dead grid
        private void initDeadGrid(ref Cell[,] grid)
        {
            grid = new Cell[gridLength, gridLength];
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    grid[i, j] = new Cell();
                    grid[i, j].IndexX = i;
                    grid[i, j].IndexY = j;
                }
            }
        }

        //initializes a random grid
        private void initRandGrid(ref Cell[,] grid)
        {
            grid = new Cell[gridLength, gridLength];
            Random rand = new Random();

            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    grid[i, j] = new Cell();
                    grid[i, j].IndexX = i;
                    grid[i, j].IndexY = j;

                    if (rand.NextDouble() > 0.2)
                    {
                        grid[i, j].Alive = false;
                        grid[i, j].Symbol = '-';
                    }
                    else {
                        grid[i, j].Alive = true;
                        grid[i, j].Symbol = 'x';
                    }
                }
            }
        }

        //add life to a cell in the current Cell[,]
        private void addLifeToCell(int x, int y)
        {
            this.currGridArr[x, y].Alive = true;
            this.currGridArr[x, y].IndexX = x;
            this.currGridArr[x, y].IndexY = y;
            int last = frames.Count - 1;
            frames.RemoveAt(last);
            frames.Add(this.currGridArr);
        }

        //remove life from a cell in the current Cell[,]
        private void removeLifeFromCell(int x, int y)
        {
            this.currGridArr[x, y].Alive = false;
            this.currGridArr[x, y].IndexX = x;
            this.currGridArr[x, y].IndexY = y;
            int last = frames.Count - 1;
            frames.RemoveAt(last);
            frames.Add(this.currGridArr);
        }

        //prints the current grid
        private void printGrid(Cell[,] grid, int numTabs=0)
        {
            for (int i = 0; i < gridLength; i++)
            {
                string tabs = "";
                for(int n = 0; n < numTabs; n++)
                {
                    tabs += "\t";
                }

                if (tabs != "")
                    Console.Write(tabs);

                for (int j = 0; j < gridLength; j++)
                {
                    if(grid[i,j].Alive == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(grid[i, j].Symbol + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //gets number of total neighbors to a cell, and number of living neighbors to a cell
        private void getNeighbors()
        {
            for (int i = 0; i < this.gridLength; i++)
            {
                for (int j = 0; j < this.gridLength; j++)
                {
                    //clear current neighbor array for each cell
                    this.currGridArr[i, j].Neighbors.Clear();

                    //if on top
                    if (i == 0)
                    {
                        //if in left corner
                        if (j == 0)
                        {
                            this.currGridArr[i, j].NumNeighbors = 3;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j + 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                        //if in right corner
                        else if (j == (this.gridLength - 1))
                        {
                            this.currGridArr[i, j].NumNeighbors = 3;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                        //just top
                        else
                        {
                            this.currGridArr[i, j].NumNeighbors = 5;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j + 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                    }
                    //if on bottom
                    else if (i == this.gridLength - 1)
                    {
                        //if in left corner
                        if (j == 0)
                        {
                            this.currGridArr[i, j].NumNeighbors = 3;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j + 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                        //if in right corner
                        else if (j == this.gridLength - 1)
                        {

                            this.currGridArr[i, j].NumNeighbors = 3;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                        //just bottom
                        else
                        {
                            this.currGridArr[i, j].NumNeighbors = 5;
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j - 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j + 1]);
                            this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                            getLivingNeighbors(ref this.currGridArr[i, j]);
                        }
                    }
                    //if on left
                    else if (j == 0)
                    {
                        this.currGridArr[i, j].NumNeighbors = 5;
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j + 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j + 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                        getLivingNeighbors(ref this.currGridArr[i, j]);
                    }
                    //if on right
                    else if (j == this.gridLength - 1)
                    {
                        this.currGridArr[i, j].NumNeighbors = 5;
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                        getLivingNeighbors(ref this.currGridArr[i, j]);
                    }
                    //if in the middle
                    else
                    {
                        this.currGridArr[i, j].NumNeighbors = 8;
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i - 1, j + 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i, j + 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j - 1]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j]);
                        this.currGridArr[i, j].Neighbors.Add(this.currGridArr[i + 1, j + 1]);
                        getLivingNeighbors(ref this.currGridArr[i, j]);
                    }
                }
            }
        }

        //helper function for get neighbors
        private void getLivingNeighbors(ref Cell currentCell)
        {
            currentCell.AliveNeighbors = 0;
            foreach (Cell neighbor in currentCell.Neighbors)
            {
                if (neighbor.Alive == true)
                {
                    currentCell.AliveNeighbors++;
                }
            }
        }

        //uses life rules defined in checkLifeRulesOnCell
        private void enactLifeRules()
        {
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    checkLifeRulesOnCell(this.currGridArr[i, j], ref this.nextGridArr[i, j]);
                }
            }
            //frames.Add(nextGridArr);
        }

        //defines Life rules and checks them against a cell
        private void checkLifeRulesOnCell(Cell currentCell, ref Cell nextFrameCell)
        {
            if (currentCell.AliveNeighbors < 2)
            {
                nextFrameCell.Alive = false;
            }
            else if (currentCell. Alive == true && (currentCell.AliveNeighbors == 3 || currentCell.AliveNeighbors == 2))
            {
                nextFrameCell.Alive = true;
            }
            else if (currentCell.AliveNeighbors > 3)
            {
                nextFrameCell.Alive = false;
            }
            else if (currentCell.Alive == false && currentCell.AliveNeighbors == 3)
            {
                nextFrameCell.Alive = true;
            }
        }

        //loops through number of frames and enacts life rules, then updates the frames
        private void setFrames(int numFrames)
        {
            for (int i = 0; i < numFrames; i++)
            {
                this.getNeighbors();
                this.enactLifeRules();
                this.updateGrids();
            }
        }

        //moves current frame to next frame and creates a new dead frame for the new next
        private void updateGrids()
        {
            int last = frames.Count - 1;
            this.currGridArr = frames[last];
            initDeadGrid(ref this.nextGridArr);
            frames.Add(this.nextGridArr);
        }

        //cycles through frames once per second
        public void play()
        {
            int runTime = 10;
            int frameDivisor = 1000;

            Console.Write("How many seconds should we run The Game of Life? ");
            try
            {
                runTime = Convert.ToInt32(Console.ReadLine());
                if(runTime <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Error: This value must be an integer greater than 0. Default run time is 10 seconds");
            }
            var t = Stopwatch.StartNew();
            int frameCount = 0;

            runTime *= 1000;

            int numFrames = runTime / frameDivisor;

            setFrames(numFrames);

            while (t.ElapsedMilliseconds <= runTime && frameCount < frames.Count)
            {
                if (t.ElapsedMilliseconds % frameDivisor == 0)
                {
                    Console.Clear();
                    printGrid(frames[frameCount]);
                    Console.WriteLine("Frame: {0}", frameCount + 1);
                    frameCount++;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
    }

    public class Cell
    {
        bool alive;
        char symbol;
        int indexX;
        int indexY;
        int numNeighbors;
        int aliveNeighbors;
        List<Cell> neighbors;

        public Cell()
        {
            Alive = false;
            indexX = 0;
            IndexY = 0;
            neighbors = new List<Cell>();
            AliveNeighbors = 0;
        }
        public List<Cell> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
                if (alive == true)
                {
                    symbol = 'x';
                }
                else
                {
                    symbol = '-';
                }
            }
        }
        public char Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }
        public int IndexX
        {
            get
            {
                return indexX;
            }
            set
            {
                indexX = value;
            }
        }
        public int IndexY
        {
            get
            {
                return indexY;
            }
            set
            {
                indexY = value;
            }
        }
        public int NumNeighbors
        {
            get
            {
                return numNeighbors;
            }
            set
            {
                numNeighbors = value;
            }
        }
        public int AliveNeighbors
        {
            get
            {
                return aliveNeighbors;
            }
            set
            {
                aliveNeighbors = value;
            }
        }
    }

    public static void Main()
    {
        
        bool cont = true;

        while (cont == true)
        {
            Grid myGrid = new Grid();

            myGrid.play();
            Console.Write("Play again? Enter 1 to play again or any other character to exit: ");
            string playAgain = Convert.ToString(Console.ReadLine());

            //check to play again
            if(playAgain == "1")
            {
                cont = true;
                Console.Clear();
            }
            else
            {
                cont = false;
            }
        }
    }
}



/*************************ideas for GUI version**********************
-sliderbar that lets user determine population density to start
-button to randomize start location
-text boxes to insert size of grid
-Play/Pause button
-Speed of iteration sliderbar
-Color options
********************************************************************/

//add the ability to save start grid after it has been randomized
//fix issue with all text turning green when living cell gets created on bottom right corner
//add wrapping on the sides
//fix input bugs
//pretty up the screens
