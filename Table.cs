using ConsoleTables;

namespace Itransition3{
    public class Table{
        string[] strings;

        public Table(string[] args)
        {
            strings = args;
        }

        public void ShowTable(){
        ConsoleTable table = new ConsoleTable(strings.Prepend("PC\\User >").ToArray());
        Rules rules = new Rules(strings.Length);

        for (int i = 0; i < strings.Length; i++){
            //creating an array to store results from each column
            string[] results = new string[strings.Length];

            //iterating through each combination and assigning a result for each
            for (int j = 0; j < strings.Length; j++){
                results[j] = rules.identifyWinner(j, i).ToString();
            }
            //creating a new object to store elements for each row
            object[] rowValues = new object[strings.Length + 1];
            rowValues[0] = strings[i];
            Array.Copy(results, 0, rowValues, 1, strings.Length);
            table.AddRow(rowValues);
        }
        //writing the table
        table.Write();
        }
}
}
