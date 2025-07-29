using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public abstract class MonoBehaviour
    {
        private Thread t;
        private bool ativo = true;

        public bool visible = false;
        public bool Input = false;
        public void Run()
        {
            Awake();
            Start();

            t = new Thread(
               () => {
                    while (ativo)
                    {
                        Update();
                        LateUpdate();
                        Thread.Sleep(80);
                    }
                }
            );

            t.Start();
        }

        public void Stop() {
            this.ativo = false;
            OnDestroy();
            t.Join();
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void OnDestroy() { }

        public abstract void Draw();



    }
}
