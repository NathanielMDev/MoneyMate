namespace MoneyMate.Models.DataPoints;

public class PieChartData
{
	public double Y { get; set; } //TotalExpense

	public string Label { get; set; }

	public List<DataPoint> DataPoints { get; set; }
}

