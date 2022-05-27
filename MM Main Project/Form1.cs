using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MM_Main_Project
{
    public class image
    {
        public int x, y,XS,YS;
        public Bitmap img;
        public int animation = 0, jump=0, gravity=0,dir=0;
        public int CanJump = 1;
        public int ClimbLadder = 0;

        public int BulletCount = 0;
        public int Axe = 0;
        public int crouch = 0;
        public int Die = 0;
        public int Mosala7 = 0, Jetpack = 0, Fly = 0, Paper = 0, ShowNote = 0;
    }
    public class CActor
    {
        public int x, y, w, h;
        public SolidBrush b = new SolidBrush(Color.Red);
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        List<image> Hero = new List<image>();
        List<image> Map = new List<image>();
        List<image> Ladders = new List<image>();
        List<image> EnemyKid = new List<image>();
        List<image> Commando = new List<image>();
        List<image> Bullet = new List<image>();
        List<image> M4a1 = new List<image>();
        List<image> Paper = new List<image>();
        List<image> Jetpack = new List<image>();
        List<image> Boss = new List<image>();
        List<CActor> BossHealth = new List<CActor>();
        List<image> Keyss = new List<image>();

        Random RR = new Random();

        Timer tt = new Timer();

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                Hero[0].dir = 0;
            }

            if (e.KeyCode == Keys.Left)
            {
                Hero[0].dir = 0;
            }

            if (e.KeyCode == Keys.Space)
            {
                if (Hero[0].Jetpack == 1)
                {
                    Hero[0].Fly = 0;
                    Hero[0].gravity = 1;
                }
            }

            Hero[0].animation = 0;
            MakeAnimation();
        }

        void MakeAnimation()
        {
            if (Hero[0].Jetpack == 1)
            {
                if (Hero[0].animation == 0)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWa2fJetpack.png");
                }
                else if (Hero[0].animation >= 1 && Hero[0].animation < 5)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk2Jetpack.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 5 && Hero[0].animation < 10)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk3Jetpack.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 10 && Hero[0].animation < 15)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk1Jetpack.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 20)
                {
                    Hero[0].animation = 1;
                }

                if (Hero[0].jump >= 1 || Hero[0].gravity == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroJumpJetpack.png");
                }

                if (Hero[0].crouch == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\CrouchJetpack.png");
                }
            }
            else if(Hero[0].Mosala7==0)
            {
                if (Hero[0].animation == 0)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWa2f.png");
                }
                else if (Hero[0].animation >= 1 && Hero[0].animation < 5)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk2.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 5 && Hero[0].animation < 10)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk3.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 10 && Hero[0].animation < 15)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk1.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 20)
                {
                    Hero[0].animation = 1;
                }

                if (Hero[0].jump >= 1 || Hero[0].gravity == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroJump.png");
                }

                if (Hero[0].crouch == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\Crouch.png");
                }

                if (Hero[0].Axe > 5 && Hero[0].Axe <= 10)
                {
                    Hero[0].img = new Bitmap("Hero\\Axe2.png");
                    Hero[0].Axe += 2;
                    AttackAxe();
                }
                else if (Hero[0].Axe > 0 && Hero[0].Axe <= 10)
                {
                    Hero[0].img = new Bitmap("Hero\\Axe1.png");
                    Hero[0].Axe += 2;
                    AttackAxe();
                }
                else if (Hero[0].Axe > 10)
                {
                    Hero[0].Axe = 0;
                }
            }
            else if (Hero[0].Mosala7==1)
            {
                if (Hero[0].animation == 0)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWa2fWeapon.png");
                }
                else if (Hero[0].animation >= 1 && Hero[0].animation < 5)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk2Weapon.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 5 && Hero[0].animation < 10)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk3Weapon.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 10 && Hero[0].animation < 15)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroWalk1Weapon.png");
                    Hero[0].animation++;
                }
                else if (Hero[0].animation >= 20)
                {
                    Hero[0].animation = 1;
                }

                if (Hero[0].jump >= 1 || Hero[0].gravity == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\HeroJumpWeapon.png");
                }

                if (Hero[0].crouch == 1)
                {
                    Hero[0].img = new Bitmap("Hero\\CrouchWeapon.png");
                }
            }
            

            if(Hero[0].ClimbLadder==1)
            {
                Hero[0].img = new Bitmap("Hero\\Climb.png");
            }

            for (int i = 0; i < EnemyKid.Count; i++)
            {
                if(EnemyKid[i].dir==3)
                {
                    EnemyKid[i].img = new Bitmap("Enemies\\EnemyKidDie.png");
                }
            }

            for (int i = 0; i < Commando.Count; i++)
            {
                if (Commando[i].dir == 1)
                {
                    Commando[i].img = new Bitmap("Enemies\\CommandDie2.jpg");

                    Commando[i].y += 50;
                    if (Commando[i].y>this.ClientSize.Height)
                    {
                        Commando.RemoveAt(i);
                    }
                }
            }


        }

        void CheckLadder()
        {
            for (int i = 0; i < Ladders.Count; i++)
            {
                if (Hero[0].x+100  > Ladders[i].x
                    &&Hero[0].x+100< Ladders[i].x+Ladders[i].img.Width
                    && Hero[0].y<Ladders[i].y+Hero[0].img.Height-100)
                {
                    Hero[0].ClimbLadder = 1;
                    Hero[0].gravity = 0;
                }
            }
            
        }

        void GetWeapon()
        {
            for (int i = 0; i < M4a1.Count; i++)
            {
                if (Hero[0].x + 150 >= M4a1[i].x)
                {
                    M4a1.RemoveAt(i);
                    Hero[0].Mosala7 = 1;
                }
            }
        }

        void GetJetpack()
        {
            for (int i = 0; i < Jetpack.Count; i++)
            {
                if (Hero[0].x + 150 >= Jetpack[i].x)
                {
                    Jetpack.RemoveAt(i);
                    Hero[0].Jetpack = 1;
                }
            }
        }

        void GetNote()
        {
            for (int i = 0; i < Paper.Count; i++)
            {
                if (Hero[0].x + 150 >= Paper[i].x && Hero[0].y<Paper[0].y+200)
                {
                    Paper.RemoveAt(i);
                    Hero[0].Paper = 1;
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                if(Hero[0].ClimbLadder == 0)
                {
                    Hero[0].dir = 1;
                    Hero[0].animation++;
                    Moves();
                }
                
            }
            if (e.KeyCode == Keys.Left)
            {
                if (Hero[0].ClimbLadder == 0)
                {
                    Hero[0].dir = 2;
                    Hero[0].animation++;
                    Moves();
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if(Hero[0].ClimbLadder==1)
                {
                    Hero[0].y -= 10;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (Hero[0].crouch == 0)
                {
                    Hero[0].crouch = 1;
                }
                else
                {
                    Hero[0].crouch = 0;
                }
            }

            if (e.KeyCode == Keys.X)
            {
                if(Hero[0].Mosala7==0)
                {
                    Hero[0].Axe = 1;
                }
                else if (Hero[0].Mosala7 == 1)
                {
                    Hero[0].Axe = 2;
                    HeroRifle();
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                if(Hero[0].Jetpack==1)
                {
                    Hero[0].Fly = 1;
                    FlyJetpack();
                }
                else if(Hero[0].CanJump==1)
                {
                    if(Hero[0].y>Ladders[0].y)
                    {
                        CheckLadder();
                    }
                    Hero[0].jump = 1;
                    Hero[0].CanJump = 0;
                }
            }
            if (e.KeyCode == Keys.E)
            {
                if (Hero[0].ShowNote == 1)
                {
                    Hero[0].ShowNote = 0;
                }
                else if (Hero[0].ShowNote == 0 && Hero[0].Paper==1)
                {
                    Hero[0].ShowNote = 1;
                }

            }
            GetJetpack();
            GetWeapon();
            GetNote();
            MoveEnemies();
            Gravity();
            MoveBullet();
            DrawDubb(this.CreateGraphics());
        }

        void checkJump()
        {
            if (Hero[0].jump >= 1)
            {
                Hero[0].y -= 20;
                Hero[0].jump += 2;
            }

            if (Hero[0].jump > 10)
            {
                Hero[0].jump = 0;
                Hero[0].gravity = 1;
            }        }

        void Gravity()
        {
            int x = 0;
            for (int i = 0; i < Map.Count; i++)
            {
                if (Hero[0].y + Hero[0].img.Height - 350 >= Map[i].y
                    &&Hero[0].y+Hero[0].img.Height-350<=Map[i].y+Map[i].img.Height-100
                    && Hero[0].x + 120 > Map[i].x
                    && Hero[0].x + 90 < Map[i].x + Map[i].img.Width - 30
                    && Hero[0].jump==0)


                {
                    Hero[0].gravity = 0;
                    Hero[0].CanJump = 1;
                    Hero[0].ClimbLadder = 0;
                    MakeAnimation();
                    x = 1;
                    break;
                }
            }
            if(x==0 && Hero[0].jump==0 && Hero[0].Fly==0)
            {
                Hero[0].gravity = 1;
                Hero[0].animation = 1;
                MakeAnimation();
            }

            if (Hero[0].gravity == 1 && Hero[0].ClimbLadder==0)
            {
                Hero[0].y += 20;
            }
    }

        void Moves()
        {
            if(Hero[0].dir==1)
            {
                if (Hero[0].x < this.ClientSize.Width - this.ClientSize.Width / 3)
                {
                    Hero[0].x += 15;
                }
                else
                {
                    //Blocks
                    for (int i = 0; i < Map.Count; i++)
                    {
                        Map[i].x -= 15;
                    }
                    //Ladder
                    for (int i = 0; i < Ladders.Count; i++)
                    {
                        Ladders[i].x -= 15;
                    }
                    //Enemies
                    for (int i = 0; i < EnemyKid.Count; i++)
                    {
                        EnemyKid[i].x -= 15;
                    }
                    //Commando
                    for (int i = 0; i < Commando.Count; i++)
                    {
                        Commando[i].x -= 15;
                    }
                    //Bullets
                    for (int i = 0; i < Bullet.Count; i++)
                    {
                        Bullet[i].x -= 15;
                    }
                    //m4a1
                    for (int i = 0; i < M4a1.Count; i++)
                    {
                        M4a1[i].x -= 15;
                    }
                    //Paper
                    for (int i = 0; i < Paper.Count; i++)
                    {
                        Paper[i].x -= 15;
                    }
                    //Jetpack
                    for (int i = 0; i < Jetpack.Count; i++)
                    {
                        Jetpack[i].x -= 15;
                    }
                    //Boss
                    for (int i = 0; i < Boss.Count; i++)
                    {
                        Boss[i].x -= 15;
                    }
                    //Keys
                    for (int i = 0; i < Keyss.Count; i++)
                    {
                        Keyss[i].x -= 15;
                    }
                }
                MakeAnimation();
            }

            if (Hero[0].dir == 2)
            {
                if (Hero[0].x > this.ClientSize.Width / 4)
                {
                    Hero[0].x -= 15;
                }
                else
                {
                    //Blocks
                    for (int i = 0; i < Map.Count; i++)
                    {
                        Map[i].x += 15;
                    }
                    //Ladder
                    for (int i = 0; i < Ladders.Count; i++)
                    {
                        Ladders[i].x += 15;
                    }
                    //Enemies
                    for (int i = 0; i < EnemyKid.Count; i++)
                    {
                        EnemyKid[i].x += 15;
                    }
                    // Commando
                    for (int i = 0; i < Commando.Count; i++)
                    {
                        Commando[i].x += 15;
                    }
                    //Bullets
                    for (int i = 0; i < Bullet.Count; i++)
                    {
                        Bullet[i].x += 15;
                    }
                    //m4a1
                    for (int i = 0; i < M4a1.Count; i++)
                    {
                        M4a1[i].x += 15;
                    }
                    //Paper
                    for (int i = 0; i < Paper.Count; i++)
                    {
                        Paper[i].x += 15;
                    }
                    //Jetpack
                    for (int i = 0; i < Jetpack.Count; i++)
                    {
                        Jetpack[i].x += 15;
                    }
                    //Boss
                    for (int i = 0; i < Boss.Count; i++)
                    {
                        Boss[i].x += 15;
                    }
                    //Keys
                    for (int i = 0; i < Keyss.Count; i++)
                    {
                        Keyss[i].x += 15;
                    }
                }
                MakeAnimation();
            }
               
        }
        void FlyJetpack()
        {
            if (Hero[0].Fly == 1)
            {
                Hero[0].y -= 10;
                Hero[0].gravity = 0;
            }
        }
        void AttackAxe()
        {
            if(Hero[0].Axe>4)
            {
                for (int i = 0; i < EnemyKid.Count; i++)
                {
                    if(Hero[0].x+100 < EnemyKid[i].x
                        && Hero[0].x + 200 > EnemyKid[i].x)
                    {
                        EnemyKid[i].dir = 3;
                        EnemyKid[i].y = Hero[0].y+120;
                    }
                }

                for (int i = 0; i < Commando.Count; i++)
                {
                    if (Hero[0].x + 100 < Commando[i].x
                        && Hero[0].x + 200 > Commando[i].x &&
                        Commando[i].dir==0)
                    {
                        Commando[i].dir = 1;
                        image pnn = new image();
                        pnn.x = Commando[i].x;
                        pnn.y = Commando[i].y+70;
                        pnn.img = new Bitmap("MapAndAssets\\M4a1.jpg");
                        pnn.img.MakeTransparent();
                        M4a1.Add(pnn);
                    }
                }
            }
        }
        void MoveEnemies()
        {
            for (int i = 0; i < EnemyKid.Count; i++)
            {
                if(EnemyKid[i].dir==0)
                {
                    EnemyKid[i].x -= 8;
                    if(EnemyKid[i].x<=Map[16].x)
                    {
                        EnemyKid[i].dir = 1;
                    }
                }

                if (EnemyKid[i].dir == 1)
                {
                    EnemyKid[i].x += 8;
                    if (EnemyKid[i].x >= Map[29].x)
                    {
                        EnemyKid[i].dir = 0;
                    }
                }
            }
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            Moves();
            Gravity();
            if(Hero[0].jump>=1)
            {
                checkJump();
            }

            if(Hero[0].Jetpack==1)
            {
                FlyJetpack();
            }
            if(Boss[0].BulletCount%10==0)
            {
                BossAttack();
            }
            Boss[0].BulletCount++;
            MoveEnemies();
            CommandoAttack();
            MoveBullet();
            MoveElevator();
            DieFromBullet();
            WinScreen();
            DrawDubb(this.CreateGraphics());
        }
        void WinScreen()
        {
            if(Boss[0].Die==1)
            {
                Boss[0].animation++;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        void MakeBoss()
        {
            image pnn = new image();
            pnn.x = Jetpack[0].x+1300;
            //pnn.x = 300;
            pnn.img = new Bitmap("Enemies\\EnemyKid1.png");
            pnn.y = 200;
            pnn.Die = 0;
            Boss.Add(pnn);
        }
        void MakeBackground()
        {
            image pnn;
            int XX = -50;

            //Blocks
            for(int i =0;i<15;i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height - pnn.img.Height+20;
                XX += pnn.img.Width-50;
                Map.Add(pnn);
            }
            //ArrowKeys
            pnn = new image();
            pnn.x = 300;
            pnn.img = new Bitmap("MapAndAssets\\ArrowKeys.png");
            pnn.y = this.ClientSize.Height/3-100;
            Keyss.Add(pnn);

            pnn = new image();
            pnn.x = 500;
            pnn.img = new Bitmap("MapAndAssets\\AttackKey.png");
            pnn.y = this.ClientSize.Height / 3-200;
            Keyss.Add(pnn);

            pnn = new image();
            pnn.x = 395;
            pnn.img = new Bitmap("MapAndAssets\\Space.png");
            pnn.y = this.ClientSize.Height / 3 + 50;
            Keyss.Add(pnn);

            pnn = new image();
            pnn.x = 340;
            pnn.img = new Bitmap("MapAndAssets\\Logo.png");
            pnn.y = this.ClientSize.Height / 3 -200;
            Keyss.Add(pnn);

            

            XX -= 200;
            //LADDER
            pnn = new image();
            pnn.x = XX;
            pnn.img = new Bitmap("MapAndAssets\\Ladder.png");
            pnn.img.MakeTransparent();
            pnn.y = this.ClientSize.Height - 400;
            Ladders.Add(pnn);

            XX -= 100;
            //More Blocks
            for(int i = 0; i < 15; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height - 500;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }
            int enemyx = 1200;
            //Enemy
            for (int i = 0; i < 3; i++)
            {
                pnn = new image();
                pnn.x = enemyx;
                pnn.img = new Bitmap("Enemies\\EnemyKid1.png");
                pnn.y = this.ClientSize.Height - 475 - pnn.img.Height;
                EnemyKid.Add(pnn);
                enemyx+=350;
            }

            XX += 50;
            //Elevator
            pnn = new image();
            pnn.x = XX;
            pnn.img = new Bitmap("MapAndAssets\\Elevator.png");
            pnn.y = this.ClientSize.Height - 450;
            pnn.dir = 1;
            Map.Add(pnn);

            XX += 400;
            //Block
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height - 500;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }

            //Commando
            pnn = new image();
            pnn.x = XX-150;
            pnn.img = new Bitmap("Enemies\\CommandAttack.jpg");
            pnn.img.MakeTransparent(Color.White);
            pnn.y = this.ClientSize.Height/2-120-pnn.img.Height+50;
            pnn.dir = 0;
            Commando.Add(pnn);

            XX += 100;
            //Block
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height - pnn.img.Height + 20;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }

            pnn = new image();
            pnn.x = XX - 600;
            pnn.img = new Bitmap("MapAndAssets\\HowTo.png");
            pnn.y = this.ClientSize.Height / 2 - 50;
            Keyss.Add(pnn);

            pnn = new image();
            pnn.x = XX+300;
            pnn.img = new Bitmap("MapAndAssets\\Run.png");
            pnn.y = 50;
            Keyss.Add(pnn);

            int XXCopy = XX;
            //More Blocks
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height - pnn.img.Height + 20;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }
            //Commando
            pnn = new image();
            pnn.x = XX - 350;
            pnn.img = new Bitmap("Enemies\\CommandAttack.jpg");
            pnn.img.MakeTransparent(Color.White);
            pnn.y = this.ClientSize.Height-70 - pnn.img.Height+35;
            pnn.dir = 0;
            Commando.Add(pnn);
            //Jetpack
            pnn = new image();
            pnn.x = XX-150;
            pnn.img = new Bitmap("MapAndAssets\\Jetpack.png");
            pnn.img.MakeTransparent(Color.White);
            pnn.y = this.ClientSize.Height - 70 - pnn.img.Height -30;
            Jetpack.Add(pnn);

            XX = XXCopy + 50;
            //More Blocks
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height/3*2 - pnn.img.Height + 20;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }
            //Commando
            pnn = new image();
            pnn.x = XX - 350;
            pnn.img = new Bitmap("Enemies\\CommandAttack.jpg");
            pnn.img.MakeTransparent(Color.White);
            pnn.y = this.ClientSize.Height/3*2-70 - pnn.img.Height+35;
            pnn.dir = 0;
            Commando.Add(pnn);
            //Paper
            pnn = new image();
            pnn.x = XX - 200;
            pnn.img = new Bitmap("MapAndAssets\\Paper.jpg");
            pnn.img.MakeTransparent();
            pnn.y = this.ClientSize.Height / 3 * 2 - 70 - pnn.img.Height - 30;
            Paper.Add(pnn);

            XX = XXCopy + 50;
            //More Blocks
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\Blocks.png");
                pnn.y = this.ClientSize.Height / 3  - pnn.img.Height + 20;
                XX += pnn.img.Width - 50;
                Map.Add(pnn);
            }
            XX -= pnn.img.Width - 50;
            int YY= this.ClientSize.Height / 3 - pnn.img.Height + 20; ;
            //More Blocks
            for (int i = 0; i < 10; i++)
            {
                pnn = new image();
                pnn.x = XX;
                pnn.img = new Bitmap("MapAndAssets\\SolidBlock.png");
                pnn.y = YY;
                YY += pnn.img.Height - 60;
                Map.Add(pnn);
            }
            MakeBoss();
        }

        void HeroRifle()
        {
            image pnn = new image();
            pnn.x = Hero[0].x + 150;
            pnn.img = new Bitmap("MapAndAssets\\Bullet.png");
            pnn.img.MakeTransparent(Color.White);
            pnn.y = Hero[0].y + 100;
            pnn.BulletCount = 0;
            pnn.Mosala7 = 1;
            Bullet.Add(pnn);
        }

        void MoveScreen()
        {
            if(Boss[0].x - Hero[0].x<200)
            {
                //Boss
                for (int i = 0; i < Boss.Count; i++)
                {
                    Boss[i].x = 800;
                }
                //Health
                if(BossHealth.Count==0)
                {
                    CActor pnn = new CActor();
                    pnn.x = this.ClientSize.Width / 4;
                    pnn.y = 20;
                    pnn.w = this.ClientSize.Width-this.ClientSize.Width / 4*2;
                    pnn.h = 30;
                    BossHealth.Add(pnn);
                }
            }
        }
        void BossAttack()
        {
            for (int i = 0; i < Boss.Count; i++)
            {
                if (Boss[i].Die == 0)
                {
                    if (Boss[i].x - Hero[0].x < 900)
                    {
                            MoveScreen();
                            image pnn = new image();
                            pnn.x = Boss[i].x +400;
                            pnn.img = new Bitmap("Enemies\\EnemyKid1.png");
                            pnn.img.MakeTransparent(Color.White);
                            pnn.y = RR.Next(50,this.ClientSize.Height);
                            pnn.BulletCount = 0;
                            pnn.Mosala7 = 0;
                            Bullet.Add(pnn);
                    }
                }
            }
        }
        void CommandoAttack()
        {
            for (int i = 0; i < Commando.Count; i++)
            {
                Commando[i].BulletCount++;
                if(Commando[i].dir==0)
                {
                    if (Commando[i].x - Hero[0].x < 1000)
                    {
                        if (Commando[i].BulletCount % 30 == 0)
                        {
                            image pnn = new image();
                            pnn.x = Commando[i].x - 10;
                            pnn.img = new Bitmap("MapAndAssets\\Bullet.png");
                            pnn.img.MakeTransparent(Color.White);
                            pnn.y = Commando[i].y + 40;
                            pnn.BulletCount = 0;
                            pnn.Mosala7 = 0;
                            Bullet.Add(pnn);
                        }
                    }
                }
            }
        }

        void MoveBullet()
        {
            for (int i = 0; i < Bullet.Count; i++)
            {
                Bullet[i].BulletCount++;
                if (Bullet[i].BulletCount<150)
                {
                    if (Bullet[i].Mosala7 == 0)
                    {
                        Bullet[i].x -= 10;
                    }
                    else if (Bullet[i].Mosala7 == 1)
                    {
                        Bullet[i].x += 20;
                        if(BossHealth.Count==1)
                        {
                            if (Bullet[i].x  >= Boss[0].x+350)
                            {
                                Bullet.RemoveAt(i);
                                BossHealth[0].x += 20;
                                BossHealth[0].w -= 20;
                                if(BossHealth[0].w<=0)
                                {
                                    Boss[0].Die = 1;
                                    Boss[0].img = new Bitmap("Enemies\\BossDie.png");
                                }
                            }
                        }
                    }
                 }
                else
                {
                    Bullet.RemoveAt(i);
                }
            }
        }

        void DieFromBullet()
        {
            for (int i = 0; i < Bullet.Count; i++)
            {
                if(Bullet[i].x<=Hero[0].x+100
                    &&Bullet[i].x+Bullet[i].img.Width>=Hero[0].x+100 &&Hero[0].crouch==0
                    &&Bullet[i].y-50<Hero[0].y
                    &&Bullet[i].y+70>Hero[0].y)
                {
                    if(Hero[0].Die==0)
                    {
                        Hero[0].Die = 1;
                    }
                }

                if (Bullet[i].Mosala7 == 1)
                {
                    for (int j = 0; j < Commando.Count; j++)
                    {
                        if (Bullet[i].x+Bullet[i].img.Width >= Commando[j].x
                         && Bullet[i].x + Bullet[i].img.Width <= Commando[j].x + 100
                         && Bullet[i].y - 150 < Commando[j].y
                         && Bullet[i].y + 180 > Commando[j].y)
                        {
                            Commando[j].dir = 1;
                        }
                    }
                }
            }
            if(Hero[0].y>this.ClientSize.Height+100)
            {
                Hero[0].Die = 1;
            }
        }
        void MoveElevator()
        {
            if(Map[30].dir==1)
            {
                Map[30].x += 10;
                if(Map[30].x+100>=Map[31].x)
                {
                    Map[30].dir = 2;
                }
            }
            else if(Map[30].dir==2)
            {
                Map[30].x -= 10;
                if (Map[30].x <= Map[29].x+Map[29].img.Width-30)
                {
                    Map[30].dir = 1;
                }
            }
        }
        void MakeHero()
        {
            image pnn = new image();
            pnn.x = 0;
            pnn.y = 480;

            pnn.img = new Bitmap("Hero\\HeroWa2f.png");

            Hero.Add(pnn);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);

            MakeHero();

            MakeBackground();
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);

            for (int i = 0; i < EnemyKid.Count; i++)
            {
                g.DrawImage(EnemyKid[i].img, EnemyKid[i].x, EnemyKid[i].y);
            }

            for (int i = 0; i < Paper.Count; i++)
            {
                g.DrawImage(Paper[i].img, Paper[i].x, Paper[i].y);
            }

            for (int i = 0; i < Jetpack.Count; i++)
            {
                g.DrawImage(Jetpack[i].img, Jetpack[i].x, Jetpack[i].y);
            }

            for (int i = 0; i < Commando.Count; i++)
            {
                g.DrawImage(Commando[i].img,
                          new Rectangle(Commando[i].x, Commando[i].y, 140, 160),    // Dst // Screen
                          new Rectangle(0, 0, Commando[i].img.Width, Commando[i].img.Height),   // Src // Image
                          GraphicsUnit.Pixel);
            }

            for (int i = 0; i < Bullet.Count; i++)
            {
                g.DrawImage(Bullet[i].img, Bullet[i].x, Bullet[i].y);
            }

            for (int i = 0; i < M4a1.Count; i++)
            {
                g.DrawImage(M4a1[i].img,
                          new Rectangle(M4a1[i].x, M4a1[i].y, 120, 70),    // Dst // Screen
                          new Rectangle(0, 0, M4a1[i].img.Width, M4a1[i].img.Height),   // Src // Image
                          GraphicsUnit.Pixel);
            }

            for (int i = 0; i < Map.Count; i++)
            {
                g.DrawImage(Map[i].img, Map[i].x, Map[i].y);
            }

            for (int i = 0; i < Keyss.Count; i++)
            {
                g.DrawImage(Keyss[i].img, Keyss[i].x, Keyss[i].y);
            }

            for (int i = 0; i < Ladders.Count; i++)
            {
                g.DrawImage(Ladders[i].img, Ladders[i].x, Ladders[i].y);
            }

            for (int i = 0; i < Boss.Count; i++)
            {
                g.DrawImage(Boss[i].img,
                          new Rectangle(Boss[i].x, Boss[i].y-600, this.ClientSize.Width, this.ClientSize.Height*2-300),    // Dst // Screen
                          new Rectangle(0, 0, Boss[i].img.Width, Boss[i].img.Height),   // Src // Image
                          GraphicsUnit.Pixel);
            }

            g.DrawImage(Hero[0].img,
                          new Rectangle(Hero[0].x, Hero[0].y, Hero[0].img.Width / 3, Hero[0].img.Height / 3),    // Dst // Screen
                          new Rectangle(0, 0, Hero[0].img.Width, Hero[0].img.Height),   // Src // Image
                          GraphicsUnit.Pixel);

            if(BossHealth.Count==1)
            {
                g.FillRectangle(BossHealth[0].b, BossHealth[0].x, BossHealth[0].y, BossHealth[0].w, BossHealth[0].h);
            }

            if(Hero[0].ShowNote==1)
            {
                Bitmap img = new Bitmap("MapAndAssets\\ShowNote.png");
                img.MakeTransparent(Color.White);
                g.DrawImage(img,
                          new Rectangle(150, 0, img.Width+200, img.Height-200  ),    // Dst // Screen
                          new Rectangle(0, 0, img.Width, img.Height),   // Src // Image
                          GraphicsUnit.Pixel);
            }

            if(Hero[0].Die==1)
            {
                Bitmap img = new Bitmap("MapAndAssets\\GameOver.png");
                g.DrawImage(img,
                          new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),    // Dst // Screen
                          new Rectangle(0, 0, img.Width, img.Height),   // Src // Image
                          GraphicsUnit.Pixel);
            }
            if(Boss[0].animation>50)
            {
                {
                    Bitmap img = new Bitmap("MapAndAssets\\Win.png");
                    g.DrawImage(img,
                              new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),    // Dst // Screen
                              new Rectangle(0, 0, img.Width, img.Height),   // Src // Image
                              GraphicsUnit.Pixel);
                }
            }
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
