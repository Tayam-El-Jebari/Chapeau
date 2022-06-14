using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.Linq;

namespace ChapeauUI
{
    public partial class OrderUI : Form
    {
        private List<MenuItem> menuList;
        private MenuItemType menuItemType;
        private MenuType menuType;
        private Reservation reservation;
        private Staff staff;
        private PopUpUI popUpUI;

        public OrderUI(Reservation reservation, Staff staff)
        {
            this.staff = staff;
            InitializeComponent();
            labelTable.Text += $"{reservation.TableId} :";
            CreateUIComponents();
            this.reservation = reservation;
            UpdateMenuList();

        }
        private void CreateButtons()
        {
            menu.Hide();
            menu.Controls.Clear();
            foreach (MenuItem menuItem in menuList)
            {
                if ((menuItem.MenuItemType == menuItemType && menuItem.MenuType == menuType) || (menuType == MenuType.Drink && menuItem.MenuType == menuType))
                {
                    LeftAndRightTextButton menuItemButton = new LeftAndRightTextButton()
                    {
                        Width = menu.Width - 100,
                        Height = 62,
                        LeftText = $"{menuItem.ProductName}",
                        RightText = $"€{menuItem.Price.ToString("0.00")}",
                        Font = new Font("Trebuchet MS", 12),
                        Margin = new Padding(6),
                        UseVisualStyleBackColor = true,
                        FlatStyle = FlatStyle.Flat,
                        // save menuItem to tag in order to retrieve it later
                        Tag = menuItem
                    };
                    menuItemButton.FlatAppearance.BorderColor = Color.FromArgb(39, 39, 39);
                    menuItemButton.FlatAppearance.BorderSize = 3;
                    if (menuItem.stock == 0)
                    {
                        menuItemButton.BackColor = Color.DarkGray;
                        menuItemButton.ForeColor = Color.LightGray;
                        menuItemButton.Text = "OUT OF STOCK";
                    }
                    else
                    {
                        menuItemButton.Click += new EventHandler(DynamicButtonClicked);
                        menuItemButton.BackColor = Color.Transparent;
                        menuItemButton.ForeColor = Color.FromArgb(39, 39, 39);
                    }
                    menu.Controls.Add(menuItemButton);
                    menuItemButton = new LeftAndRightTextButton()
                    {
                        Width = 44,
                        Height = 44,
                        Text = "?",
                        Font = new Font("Trebuchet MS", 9),
                        ForeColor = Color.FromArgb(39, 39, 39),
                        BackColor = Color.Transparent,
                        FlatStyle = FlatStyle.Flat,
                    };
                    menuItemButton.FlatAppearance.BorderColor = Color.FromArgb(39, 39, 39);
                    menuItemButton.FlatAppearance.BorderSize = 2;
                    menuItemButton.Click += new EventHandler(DynamicButtonClicked);
                    menu.Controls.Add(menuItemButton);
                }
            }
            menu.Show();
        }
        private void UpdateMenuList()
        {
            MenuItemService menuItemService = new MenuItemService();
            menuList = menuItemService.GetMenuItems();
        }
        private void CreateUIComponents()
        {
            itemGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Add",
                Text = "+",
                Name = "btnAddOrderItems",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 70
            });
            itemGridView.Columns.Add(
                new DataGridViewButtonColumn
                {
                    HeaderText = "Min",
                    Text = "-",
                    Name = "btnAddOrderItems",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    Width = 70
                });
        }
        void DynamicButtonClicked(Object sender, EventArgs e)
        {
            Button buttonClicked = (sender as Button);
            if (buttonClicked.Tag is MenuItem)
            {
                //check the corresponding menuItem in list, so information from list could be retrieved, e.g. stock
                int itemIndex = menuList.FindIndex(x => x == buttonClicked.Tag);
                --menuList[itemIndex].stock;
                if (menuList[itemIndex].stock == 0)
                {
                    //make button unclickable
                    buttonClicked.BackColor = Color.DarkGray;
                    buttonClicked.ForeColor = Color.LightGray;
                    buttonClicked.Text = "OUT OF STOCK";
                    buttonClicked.Click -= new EventHandler(DynamicButtonClicked);
                }
                foreach (DataGridViewRow row in itemGridView.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == menuList[itemIndex].MenuItemId)
                    {
                        row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                        return;
                    }
                }
                itemGridView.Rows.Add(new string[] { menuList[itemIndex].MenuItemId.ToString(), menuList[itemIndex].ProductName, "1" });
            }
            else
            {
                for (int i = 0; i < menu.Controls.Count; i++)
                {
                    if (menu.Controls[i] == sender)
                    {
                        MenuItem menuItem = (menu.Controls[i - 1].Tag as MenuItem);
                        PopUpUI popup = new PopUpUI(menuItem.Description, DialogResult.OK);
                        popup.ShowDialog();
                    }
                }
            }
            
        }
        private void viewOrder_Click(object sender, EventArgs e)
        {
            if (itemAddedOrderPnl.Visible)
            {
                //menu gets hidden in order to prevent visual bugs for the paint function of panel menu
                menu.Hide();
                viewOrder.Text = "VIEW ORDER";
                itemAddedOrderPnl.Hide();
                menu.Show();
            }
            else
            {
                viewOrder.Text = "CLOSE ORDER";
                itemAddedOrderPnl.Show();
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            PopUpUI confirmBackButton = new PopUpUI("Are you sure you wish to clear all?");
            confirmBackButton.ShowDialog();
            if (confirmBackButton.DialogResult == DialogResult.Yes)
            {
                itemGridView.Rows.Clear();
                UpdateMenuList();
                PanelChooseMenu.Visible = true;
                viewOrder_Click(sender, e);
            }
            
        }
        private void itemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && itemGridView.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int MenuListIndexOfItem = menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value));
                if (e.ColumnIndex == 3)
                {
                    if (menuList[MenuListIndexOfItem].stock == 0)
                    {
                        popUpUI = new PopUpUI("Item is out of stock.", DialogResult.OK);
                        popUpUI.ShowDialog();
                        return;
                    }
                    menuList[MenuListIndexOfItem].stock -= 1;
                    itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) + 1;
                    if (menuList[MenuListIndexOfItem].stock == 0)
                    {
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                            // check tag of all controls, if menuItem corresponds to control.tag and is not in stock, make control unclickable
                            if (menu.Controls[i].Tag == menuList[MenuListIndexOfItem])
                            {
                                menu.Controls[i].BackColor = Color.DarkGray;
                                menu.Controls[i].ForeColor = Color.LightGray;
                                menu.Controls[i].Click -= new EventHandler(DynamicButtonClicked);
                                menu.Controls[i].Text = "OUT OF STOCK";
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    List<MenuItem> itemsWithMenuType = menuList.FindAll(x => x.MenuItemType == menuItemType);
                    if (menuList[MenuListIndexOfItem].stock == 0)
                    {
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                            // check tag of all controls, if menuItem corresponds to control.tag and is in stock, make control clickable
                            if (menu.Controls[i].Tag == menuList[MenuListIndexOfItem])
                            {
                                menu.Controls[i].BackColor = Color.Transparent;
                                menu.Controls[i].ForeColor = Color.FromArgb(39, 39, 39);
                                menu.Controls[i].Click += new EventHandler(DynamicButtonClicked);
                                menu.Controls[i].Text = string.Empty;
                            }
                        }
                    }
                    itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) - 1;
                    menuList[MenuListIndexOfItem].stock += 1;

                    if (Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) == 0)
                    {
                        itemGridView.Rows.Remove(itemGridView.Rows[e.RowIndex]);
                    }
                }
            }
        }
        private void itemAddedOrderPnl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 39, 39), 10), 13, 578, 652, 224);
        }
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            if(itemGridView.Rows.Count == 1)
            {
                popUpUI = new PopUpUI("No items added!", DialogResult.OK);
                popUpUI.ShowDialog();
                return;
            }
            PopUpUI popUp = new PopUpUI();
            popUp.ShowDialog();
            if (popUp.DialogResult == DialogResult.Yes)
            {
                Order orderToSend = new Order() 
                {
                    Comments = commentsTextBox.Text, 
                    OrderItems = new List<OrderItem>(), 
                    Reservation = this.reservation,
                    StaffId = staff.Staff_ID
                };
                List<OrderItem> itemsForOrder = new List<OrderItem>();
                for(int i = 0; i < itemGridView.Rows.Count - 1; i++)
                {
                    orderToSend.OrderItems.Add(new OrderItem
                    {
                        MenuItem = new MenuItem{MenuItemId = Convert.ToInt32(itemGridView.Rows[i].Cells[0].Value)},
                        Amount = Convert.ToInt32(itemGridView.Rows[i].Cells[2].Value)
                    });
                }
                OrderService orderService = new OrderService();
                orderService.CreateCompleteOrder(orderToSend);
                itemGridView.Rows.Clear();
                viewOrder_Click(sender, e);
                PanelChooseMenu.Visible = true;
                commentsTextBox.Text = string.Empty;
            }
        }

        private void buttonChooseMenuAndMenuType_Click(object sender, EventArgs e)
        {
            PanelChooseMenu.Hide();
            if (sender == buttonStarters)
            {
                menuItemType = MenuItemType.Starter;
            }
            else if(sender == buttonMainCourse)
            {
                menuItemType = MenuItemType.MainCourse;
            }
            else if(sender == buttonDesserts)
            {
                menuItemType = MenuItemType.Desserts;
            }
            else if(sender == buttonDrinks)
            {
                menuType = MenuType.Drink;
                menuItemType = MenuItemType.Drink; 
            }
            else
            {
                if (sender == buttonLunch)
                {
                    menuType = MenuType.Lunch;
                    labelTitleItems.Text = $"{menuType} 11:00 - 16:00";
                }
                else if (sender == buttonDinner)
                {
                    menuType = MenuType.Dinner;
                    labelTitleItems.Text = $"{menuType} 17:00 - 21:00";
                }
                panelSelectTheThreeCourseMeal.Show();
                return;
            }
            panelSelectTheThreeCourseMeal.Hide();
            CreateButtons();
            labelSelectedMenuName.Text = $"{menuItemType}";

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(menuType == MenuType.Drink)
            {
                PanelChooseMenu.Visible = true;
            }
            else if (!panelSelectTheThreeCourseMeal.Visible)
            {
                panelSelectTheThreeCourseMeal.Visible = true;
            }
            else if (!PanelChooseMenu.Visible)
            {
                PanelChooseMenu.Visible = true;
            }
            else if (PanelChooseMenu.Visible)
            {
                this.Close();
            }
        }
    }
}
