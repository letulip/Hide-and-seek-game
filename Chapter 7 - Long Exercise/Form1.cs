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

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(frontYard);
            
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

            if (currentLocation is IHasExteriorDoor)
                btnThruDoor.Visible = true;
            else
                btnThruDoor.Visible = false;

            tbxDescription.Text = currentLocation.Description;

            for (int i = 0; i < currentLocation.Exits.Length; i++)
                cmbxExits.Items.Add(currentLocation.Exits[i].Name);
            cmbxExits.SelectedIndex = 0;
        }

        private void CreateObjects()
        {
            garden = new Outside("Garden", true);
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door.");
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with brass knob.");
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with brass knob.");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door.");
            diningRoom = new Room("Dining Room", "table in the middle and the sofa");

            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };

            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }
    }
}
