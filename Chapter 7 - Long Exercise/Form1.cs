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

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(driveWay);
            
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
            driveWay = new Outside("Driveway", false);
            garage = new Outside("Garage", false);
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door.");
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with brass knob.");
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with brass knob.");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door.");
            diningRoom = new Room("Dining Room", "table in the middle and the sofa");
            stairs = new Room("Stairs", "wooden bannister");
            upstairsHallway = new Room("Upstairs hallway", "picture of a dog and closet");
            masterBedroom = new Room("Master bedroom", "large bed");
            guestBedroom = new Room("Guest bedroom", "couple small beds");
            bathroom = new Room("Bathroom", "shower, sink and toilet");

            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };
            driveWay.Exits = new Location[] { frontYard, garage };
            garage.Exits = new Location[] { driveWay, frontYard };

            livingRoom.Exits = new Location[] { diningRoom, stairs };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            stairs.Exits = new Location[] { upstairsHallway, livingRoom };
            upstairsHallway.Exits = new Location[] { masterBedroom, guestBedroom, bathroom };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            guestBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }
    }
}
