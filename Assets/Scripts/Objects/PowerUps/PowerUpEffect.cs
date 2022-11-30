using UnityEngine;

namespace Game.Objects.PowerUps
{
    public abstract class PowerUpEffect : MonoBehaviour
    {
	    [SerializeField] private float _maxTime = 2f;
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

	    protected abstract void Activate();
        protected abstract void Desactivate();
        
		
	}

    
}
