using UnityEngine;


// written with some help from Claude AI

public abstract class PlayerEnergy : MonoBehaviour
{

    public int maxEnergy = 1440;
    public int currentEnergy;
    public EnergyBar energyBar;

    public bool isAwake = true;
    public KeyCode inputSleep;

    // Base energy drain/recovery rates as properties that can be overridden
    [SerializeField] 
    private int _baseEnergyLossRate = 1;
    public virtual int BaseEnergyLossRate { 
        get { return _baseEnergyLossRate; } 
        protected set { _baseEnergyLossRate = value; } 
    }

    public int recoveryRate = 30;


    protected virtual void Awake() {
        // subscribe to time events
        TimeManager.OnHourChanged += OnHourChanged;
        TimeManager.OnMinuteChanged += OnMinuteChanged;
    }


    protected virtual void OnDestroy() {
        // clean up subscriptions
        TimeManager.OnHourChanged -= OnHourChanged;
        TimeManager.OnMinuteChanged -= OnMinuteChanged;
    }


    // initialize energy values
    public abstract void Initialize();


    // called at the start to set initial values
    protected virtual void Start() {
        Initialize();
    }


    protected virtual void Update()
    {
        // manually activate or deactivate sleep
        if (Input.GetKeyDown(inputSleep)) {
            isAwake = !isAwake;
        }

        // fall asleep if energy depletes
        if (currentEnergy <= 0) {
            isAwake = false;
        }

        // wake up if energy is full
        if (currentEnergy >= maxEnergy) {
            isAwake = true;
        }
    }


    // called when 15 min in game time passes
    protected void OnMinuteChanged() {    
        // lose or gain energy depending on whether player is awake
        if (isAwake) {
            LoseEnergy(CalculateEnergyLossRate());
        } else {
            IncreaseEnergy(recoveryRate);
        }
    }


    // called when the hour changes
    protected virtual void OnHourChanged() {    
        // override in child classes 
    }


    // calculate energy loss based on time of day and player
    protected virtual int CalculateEnergyLossRate() {
        return BaseEnergyLossRate;
    }


    protected void LoseEnergy(int energy) {
        currentEnergy = Mathf.Max(0, currentEnergy - energy);
        energyBar.SetEnergy(currentEnergy);
    }


    protected void IncreaseEnergy(int energy) {
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy + energy);
        energyBar.SetEnergy(currentEnergy);
    }


    protected void SetEnergy(int energy) {
        currentEnergy = Mathf.Clamp(energy, 0, maxEnergy);
        energyBar.SetEnergy(currentEnergy);
    }
}
