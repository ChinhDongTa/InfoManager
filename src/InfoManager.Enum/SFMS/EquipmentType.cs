namespace InfoManager.Enum.SFMS;

public enum EquipmentType
{
    [Display(Name = "Máy kéo")]
    Tractor,

    [Display(Name = "Máy bơm")]
    Pump,

    [Display(Name = "Máy phun / Bình phun")]
    Sprayer,

    [Display(Name = "Cào đất / Harrow")]
    Harrow,

    [Display(Name = "Máy gieo hạt")]
    Seeder,

    [Display(Name = "Máy cấy")]
    Transplanter,

    [Display(Name = "Máy thu hoạch liên hợp")]
    CombineHarvester,

    [Display(Name = "Máy cày")]
    Plow,

    [Display(Name = "Máy xới / Cultivator")]
    Cultivator,

    [Display(Name = "Máy xới quay / Rotary Tiller")]
    RotaryTiller,

    [Display(Name = "Rơ moóc / Trailer")]
    Trailer,

    [Display(Name = "Xe nâng")]
    Forklift,

    [Display(Name = "Máy phát điện")]
    Generator,

    [Display(Name = "Máy bơm tưới")]
    IrrigationPump,

    [Display(Name = "Drone (máy bay không người lái)")]
    Drone,

    [Display(Name = "Máy kiểm tra đất")]
    SoilTester,

    [Display(Name = "Máy sưởi nhà kính")]
    GreenhouseHeater,

    [Display(Name = "Tấm pin năng lượng mặt trời")]
    SolarPanel,

    [Display(Name = "Bồn chứa nước")]
    WaterTank,

    [Display(Name = "Máy rải phân")]
    FertilizerSpreader,

    [Display(Name = "Máy khoan gieo hạt (Drill)")]
    SeederDrill,

    [Display(Name = "Máy băm / Mulcher")]
    Mulcher,

    [Display(Name = "Máy cuộn rơm / Baler")]
    Baler,

    [Display(Name = "Hệ thống tưới phun (Sprinkler)")]
    SprinklerSystem,

    [Display(Name = "Dụng cụ cầm tay")]
    HandTool,

    [Display(Name = "Băng tải")]
    Conveyor,

    [Display(Name = "Kho lạnh / Cold Storage")]
    ColdStorage,

    [Display(Name = "Cân điện tử")]
    WeighingScale,

    [Display(Name = "Cảm biến / Node cảm biến")]
    SensorNode,

    [Display(Name = "Pin dự phòng")]
    BatteryPack,

    [Display(Name = "Bộ sạc")]
    Charger,

    [Display(Name = "Khác")]
    Other
}