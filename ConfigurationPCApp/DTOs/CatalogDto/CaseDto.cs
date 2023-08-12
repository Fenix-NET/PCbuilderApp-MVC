namespace PcBuilderApp.DTOs.CatalogDto
{
    public class CaseDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public string? Type { get; set; }
		public string? Form { get; set; }
		public string? PsuFormat { get; set; }
		public string? MaxPsuLength { get; set; }
		public string? UsbConnectors { get; set; }
		public string? PanelConnector { get; set; }
		public string? PanelButton { get; set; }
		public string? InternalBays25 { get; set; }
		public string? InternalBays35 { get; set; }
		public string? MaxCoolerHeight { get; set; }
		public string? MaxGpuLenght { get; set; }

		public string? Materials { get; set; }
		public string? Size { get; set; }
		public string? Mass { get; set; }

		public decimal? Price { get; set; }
		public string ImageName { get; set; }
	}
}
