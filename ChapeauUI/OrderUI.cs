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
        private int staffId;

        public OrderUI(Reservation reservation, int staffId)
        {
            this.staffId = staffId;
            InitializeComponent();
            labelTable.Text += $"{reservation.TableId} :";
            CreateUIComponents();
            this.reservation = reservation;
            UpdateMenuList();

        }
        private void CreateButtons()
        {
            menu.Hide();
            foreach (MenuItem menuItem in menuList)
            {
                if ((menuItem.MenuItemType == menuItemType && menuItem.MenuType == menuType) || (menuType == MenuType.Drink && menuItem.MenuType == menuType))
                {
                    LeftAndRightTextButton menuItemButton = new LeftAndRightTextButton()
                    {
                        Width = menu.Width - 70,
                        Height = 62,
                        LeftText = $"{menuItem.ProductName}",
                        RightText = $"€{menuItem.Price.ToString("0.00")}",
                        Font = new Font("Cabin", 15),
                        Margin = new Padding(6),
                        UseVisualStyleBackColor = true,
                        FlatStyle = FlatStyle.Flat,

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
                        menuItemButton.Click += new EventHandler(BtnOrderAdd_Click);
                        menuItemButton.BackColor = Color.Transparent;
                        menuItemButton.ForeColor = Color.FromArgb(39, 39, 39);
                    }
                    menu.Controls.Add(menuItemButton);
                    menuItemButton = new LeftAndRightTextButton()
                    {
                        Width = 44,
                        Height = 44,
                        Text = "?",
                        Font = new Font("Cabin", 9),
                        ForeColor = Color.FromArgb(39, 39, 39),
                        BackColor = Color.Transparent,
                        FlatStyle = FlatStyle.Flat,
                    };
                    menuItemButton.FlatAppearance.BorderColor = Color.FromArgb(39, 39, 39);
                    menuItemButton.FlatAppearance.BorderSize = 2;
                    menuItemButton.Click += new EventHandler(BtnDescriptionShow);
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
            itemGridView.ColumnCount = 3;
            itemGridView.Columns[0].Name = "Menu Nr";
            itemGridView.Columns[1].Name = "Product Name";
            itemGridView.Columns[2].Name = "amount added";
            itemGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Add",
                Text = "+",
                Name = "btnAddOrderItems",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 50
            });
            itemGridView.Columns.Add(
                new DataGridViewButtonColumn
                {
                    HeaderText = "Min",
                    Text = "-",
                    Name = "btnAddOrderItems",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    Width = 50
                });
        }
        void BtnOrderAdd_Click(Object sender, EventArgs e)
        {
            List<MenuItem> itemsWithMenuType = menuList.FindAll(x => x.MenuItemType == menuItemType && x.MenuType == menuType);
            for (int i = 0; i < menu.Controls.Count; i++)
            {
                if (menu.Controls[i] == sender)
                {
                    menuList.Find(x => x == itemsWithMenuType[i / 2]).stock--;
                    foreach (DataGridViewRow row in itemGridView.Rows)
                    {
                        if(Convert.ToInt32(row.Cells[0].Value) == itemsWithMenuType[i / 2].MenuItemId)
                        {
                            row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                            if (itemsWithMenuType[i / 2].stock == 0)
                            {
                                menu.Controls[i].BackColor = Color.DarkGray;
                                menu.Controls[i].ForeColor = Color.LightGray;
                                menu.Controls[i].Text = "OUT OF STOCK";
                                menu.Controls[i].Click -= new EventHandler(BtnOrderAdd_Click);
                            }
                            return;
                        }
                    }
                    itemGridView.Rows.Add(new string[] { itemsWithMenuType[i / 2].MenuItemId.ToString(), itemsWithMenuType[i / 2].ProductName, "1"});
                }
            }
        }
        public void BtnDescriptionShow(object sender, EventArgs e)
        {
            for (int i = 0; i < menu.Controls.Count; i++)
            {
                if (menu.Controls[i] == sender)
                {
                    MessageBox.Show(menuList[i / 2].Description);
                }
            }
        }

        private void viewOrder_Click(object sender, EventArgs e)
        {
            if (itemAddedOrderPnl.Visible)
            {
                viewOrder.Text = "VIEW ORDER";
                itemAddedOrderPnl.Hide();
            }
            else
            {
                viewOrder.Text = "CLOSE ORDER";
                itemAddedOrderPnl.Show();
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            itemGridView.Rows.Clear();
            UpdateMenuList();
            CreateButtons();
    
        }

        private void itemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value) != 0)
            {
                if (e.ColumnIndex == 3)
                {
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 0)
                    {
                        MessageBox.Show("Item is out of stock.");
                        return;
                    }
                    menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock -= 1;
                    itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) + 1;
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 0)
                    {
                        List<MenuItem> itemsWithMenuType = menuList.FindAll(x => x.MenuItemType == menuItemType);
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                                if (i % 2 == 0 && itemsWithMenuType[i / 2].stock == 0)
                                {
                                    menu.Controls[i].BackColor = Color.DarkGray;
                                    menu.Controls[i].ForeColor = Color.LightGray;
                                    menu.Controls[i].Click -= new EventHandler(BtnOrderAdd_Click);
                                    menu.Controls[i].Text = "OUT OF STOCK";
                                }
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) - 1;
                    menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock += 1;
                    List<MenuItem> itemsWithMenuType = menuList.FindAll(x => x.MenuItemType == menuItemType);
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 1)
                    {
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                if (itemsWithMenuType[i / 2].stock == 1)
                                {
                                    menu.Controls[i].BackColor = Color.Transparent;
                                    menu.Controls[i].ForeColor = Color.FromArgb(39, 39, 39);
                                    menu.Controls[i].Click += new EventHandler(BtnOrderAdd_Click);
                                    menu.Controls[i].Text = string.Empty;
                                }
                            }
                            
                        }
                    }
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
                MessageBox.Show("No items added!");
                return;
            }
            ConfirmOrderUI confirm = new ConfirmOrderUI();
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                List<OrderItem> itemsForOrder = new List<OrderItem>();
                for(int i = 0; i < itemGridView.Rows.Count - 1; i++)
                {
                    itemsForOrder.Add(new OrderItem
                    {
                        MenuItem = new MenuItem{MenuItemId = Convert.ToInt32(itemGridView.Rows[i].Cells[0].Value)},
                        Amount = Convert.ToInt32(itemGridView.Rows[i].Cells[2].Value)
                    });
                }
                OrderService orderService = new OrderService();
                orderService.CreateCompleteOrder(itemsForOrder, reservation, commentsTextBox.Text, staffId);
                itemGridView.Rows.Clear();
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
                    labelTitleItems.Text = $"{menuType} 11:00 - 16:00";
                }
                panelSelectMenu.Show();
                return;
            }
            panelSelectMenu.Hide();
            CreateButtons();
            labelSelectedMenuName.Text = $"{menuItemType}";

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            RemoveAllControlsMenu();
            if(menuType == MenuType.Drink)
            {
                PanelChooseMenu.Visible = true;
            }
            else if (!panelSelectMenu.Visible)
            {
                panelSelectMenu.Visible = true;
            }
            else if(!PanelChooseMenu.Visible)
            {
                PanelChooseMenu.Visible = true;
            }
            else
            {
                this.Close();
            }
        }
        private void RemoveAllControlsMenu()
        {
           // hide and show in order to prevent visual bugs from .controls.Clear() that is caused from there being too many controls.
           menu.Hide();
           menu.Controls.Clear();
           menu.Show();
        }
    }
}
