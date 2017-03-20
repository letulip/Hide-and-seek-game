using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_7___Long_Exercise
{
    public partial class Form1 : Form
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        Room stairs;
        Room upstairsHallway;
        Room masterBedroom;
        Room guestBedroom;
        Room bathroom;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;
        Outside driveWay;
        Outside garage;

        Opponent opponent;

        int movesCount;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            //MoveToANewLocation(driveWay);
            currentLocation = driveWay;
            tbxDescription.Text = "You and your opponent standing on " + currentLocation.Name;
        }

        private void btnGoHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[cmbxExits.SelectedIndex]);
        }

        private void btnThruDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }
        
        private void MoveToANewLocation(Location loc)
        {
            currentLocation = loc;
            cmbxExits.Items.Clear();
            movesCount++;

            if (currentLocation is IHasExteriorDoor)
                btnThruDoor.Visible = true;
            else
                btnThruDoor.Visible = false;

            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                btnCheck.Text = "Check " + hidingPlace.HidingPlaceName;
                btnCheck.Visible = true;
            }

            tbxDescription.Text = currentLocation.Description;

            for (int i = 0; i < currentLocation.Exits.Length; i++)
                cmbxExits.Items.Add(currentLocation.Exits[i].Name);
            cmbxExits.SelectedIndex = 0;
        }

        private void CreateObjects()
        {
            garden = new OutsideHiding("Garden", true, "in bushes");
            driveWay = new Outside("Driveway", false);
            garage = new OutsideHiding("Garage", false, "behind the car");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door.");
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with brass knob.");
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "inside the closet", "an oak door with brass knob.");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "in the cabinet", "a screen door.");
            diningRoom = new InsideHiding("Dining Room", "table in the middle and the sofa", "in the tall armoire");
            stairs = new Room("Stairs", "wooden bannister");
            upstairsHallway = new InsideHiding("Upstairs hallway", "picture of a dog and closet", "in the closet");
            masterBedroom = new InsideHiding("Master bedroom", "large bed", "under the bed");
            guestBedroom = new InsideHiding("Guest bedroom", "couple small beds", "under the bed");
            bathroom = new InsideHiding("Bathroom", "shower, sink and toilet", "behind bath certain");

            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };
            driveWay.Exits = new Location[] { frontYard, garage };
            garage.Exits = new Location[] { driveWay, frontYard };

            livingRoom.Exits = new Location[] { diningRoom, stairs };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            stairs.Exits = new Location[] { upstairsHallway, livingRoom };
            upstairsHallway.Exits = new Location[] { masterBedroom, guestBedroom, bathroom, stairs };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            guestBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            movesCount++;

            if(opponent.Check(currentLocation))
            {
                if (MessageBox.Show("Would you like to continue?", "You've found the opponent!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    ResetGame();
                else
                    Close();
                
            }
            else
            {
                tbxDescription.Text += " You found no one here!";
                btnCheck.Visible = false;
            }
            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide.Visible = false;

            opponent = new Opponent(driveWay);

            if (currentLocation is IHidingPlace)
                btnCheck.Visible = true;

            for (int i = 0; i < 10; i++)
            {
                tbxDescription.Text = (i + 1) + "...";
                opponent.Move();
                Application.DoEvents();
                System.Threading.Thread.Sleep(250);
            }

            tbxDescription.Text = "Ready or not, here I come!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            
            MoveToANewLocation(driveWay);
            tbxDescription.Text = currentLocation.Description;

            btnGoHere.Visible = true;
            cmbxExits.Visible = true;

        }

        private void ResetGame()
        {
            IHidingPlace foundLocation = currentLocation as IHidingPlace;
            tbxDescription.Text = "You've found opponent here: " + currentLocation.Name + foundLocation.HidingPlaceName + ". It took you " + movesCount + " moves.";

            movesCount = 0;
            btnHide.Visible = true;
            btnCheck.Visible = false;
            btnGoHere.Visible = false;
            btnThruDoor.Visible = false;
            cmbxExits.Visible = false;
        }
    }
}
