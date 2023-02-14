using UnityEngine;
using Game.Managers;

namespace Game.Objects.PowerUps
{
    public abstract class PowerUpEffect : MonoBehaviour //TPFinal - * Federico Krug *.
	{
	    [SerializeField] private float _maxTime = 2f;
	    [SerializeField] protected Color color;
	    private float _time = float.MaxValue;

	    private void OnEnable()
	    {
		    _time = _maxTime;
		    Activate();
	    }

	    private void Update()
	    {
		    if (_time > 0)
				_time -= Time.deltaTime;
		    else
		    {
			    DestroyEffect();
		    }
	    }

	    private void DestroyEffect()
	    {
		    Desactivate();
		    Destroy(gameObject);
	    }
	    private void Activate()
	    {
		    GameManager.Instance.ActivatePowerUp(color);
		    ActivateEffect();
	    }

	    private void Desactivate()
	    {
		    GameManager.Instance.DefaultPowerUp();
		    DesactivateEffect();
	    }
	    protected abstract void ActivateEffect();
	    protected abstract void DesactivateEffect();
        
		
	}

    
}
