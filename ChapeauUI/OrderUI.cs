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
    public partial class Topbar : Form
    {
        private List<MenuItem> menuList;
        private MenuItemType menuItemType;
        private bool selectLunchMenu;
        private Reservation reservation;

        public Topbar(Reservation reservation)
        {
            InitializeComponent();
            labelTable.Text += $"{reservation.TableId} :";
            CreateUIComponents();
            this.reservation = reservation;
        }
        private void CreateButtons()
        {
            MenuItemService menuItemService = new MenuItemService();
            menuList = menuItemService.GetMenuItems(selectLunchMenu, menuItemType);
            foreach (MenuItem menuItem in menuList)
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
                menuItemButton.FlatAppearance.BorderSize = 4;
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
            this.panelItems.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOrders_Paint);
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
            });
            itemGridView.Columns.Add(
                new DataGridViewButtonColumn
                {
                    HeaderText = "Remove",
                    Text = "-",
                    Name = "btnAddOrderItems",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat

                });
        }
        void BtnOrderAdd_Click(Object sender, EventArgs e)
        {
            for (int i = 0; i < menu.Controls.Count; i++)
            {
                if (menu.Controls[i] == sender)
                {
                    menuList[i / 2].stock--;
                    foreach (DataGridViewRow row in itemGridView.Rows)
                    {
                        if(Convert.ToInt32(row.Cells[0].Value) == menuList[i / 2].MenuItemId)
                        {
                            row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                            if (menuList[i / 2].stock == 0)
                            {
                                menu.Controls[i].BackColor = Color.DarkGray;
                                menu.Controls[i].ForeColor = Color.LightGray;
                                menu.Controls[i].Text = "OUT OF STOCK";
                                menu.Controls[i].Click -= new EventHandler(BtnOrderAdd_Click);
                                return;
                            }
                            return;
                        }
                    }
                    itemGridView.Rows.Add(new string[] { menuList[i / 2].MenuItemId.ToString(), menuList[i / 2].ProductName, "1"});
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
            panelSelectMenu.Show();
            foreach (Control item in menu.Controls.OfType<Button>().ToList())
            {
                menu.Controls.Remove(item);
            }
            
        }

        private void panelOrders_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 39, 39), 10), 14, 20, 498, 81);
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
        }

        private void itemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value) != 0)
            {
                if (e.ColumnIndex == 3)
                {
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 0)
                        return;

                    menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock -= 1;
                    itemGridView.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[2].Value) + 1;
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 0)
                    {
                        itemGridView.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.DarkGray;
                        itemGridView.Rows[e.RowIndex].Cells[3].Value = "OUT";
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                                if (i % 2 == 0 && menuList[i / 2].stock == 0)
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
                    if (menuList[menuList.FindIndex(x => x.MenuItemId == Convert.ToInt32(itemGridView.Rows[e.RowIndex].Cells[0].Value))].stock == 1)
                    {
                        for (int i = 0; i < menu.Controls.Count; i++)
                        {
                            if (i % 2 == 0 && menuList[i / 2].stock == 1)
                            {
                                menu.Controls[i].BackColor = Color.Transparent;
                                menu.Controls[i].ForeColor = Color.FromArgb(39, 39, 39);
                                menu.Controls[i].Click += new EventHandler(BtnOrderAdd_Click);
                                menu.Controls[i].Text = string.Empty;
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
            ConfirmOrderUI confirm = new ConfirmOrderUI(MessageBoxButtons.YesNo);
            confirm.ShowDialog();
            DialogResult confirmation = confirm.DialogResult;
            if (confirmation == DialogResult.Yes)
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
                //temporarily creating new reservation in order to test system, will be 
                OrderService orderService = new OrderService();
                orderService.CreateCompleteOrder(itemsForOrder, reservation, commentsTextBox.Text);
                itemGridView.Rows.Clear();
            }

        }

        private void buttonLunch_Click(object sender, EventArgs e)
        {
            selectLunchMenu = true;
            labelTitleItems.Text = "LUNCH 11:00 - 16:00";
            PanelChooseMenu.Hide();
        }

        private void buttonDinner_Click(object sender, EventArgs e)
        {
            selectLunchMenu = false;
            labelTitleItems.Text = "DINNER 17:00 - 21:00";
            
            PanelChooseMenu.Hide();
        }

        private void buttonStarters_Click(object sender, EventArgs e)
        {
            menuItemType = MenuItemType.Starter;
            CreateButtons();
            labelSelectedMenuName.Text = "STARTERS";
            panelSelectMenu.Hide();
        }

        private void buttonMainCourse_Click(object sender, EventArgs e)
        {
            menuItemType = MenuItemType.MainCourse;
            CreateButtons();
            labelSelectedMenuName.Text = "MAIN COURSE";
            panelSelectMenu.Hide();
        }

        private void buttonDesserts_Click(object sender, EventArgs e)
        {
            menuItemType = MenuItemType.Desserts;
            CreateButtons();
            labelSelectedMenuName.Text = "DESSERTS";
            panelSelectMenu.Hide();
        }

        private void buttonDrinks_Click(object sender, EventArgs e)
        {
            menuItemType = MenuItemType.Drinks;
            CreateButtons();
            labelSelectedMenuName.Text = "DRINKS";
            panelSelectMenu.Hide();
        }
        public class LeftAndRightTextButton : Button
        {
            public string LeftText { get; set; }
            public string RightText { get; set; }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                SolidBrush leftTextBrush = new SolidBrush(this.ForeColor);

                //hide left text when stock isn't available
                if (this.ForeColor == Color.LightGray)
                {
                    leftTextBrush = new SolidBrush(Color.Transparent);
                }
                using (leftTextBrush)
                {
                    using (StringFormat sf = new StringFormat()
                    { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                    {
                        pevent.Graphics.DrawString(LeftText, this.Font, leftTextBrush, this.ClientRectangle, sf);
                    }
                }
                using (StringFormat sf = new StringFormat()
                { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near })
                {
                    pevent.Graphics.DrawString(RightText, new Font(this.Font.FontFamily, this.Font.Size - 2), new SolidBrush(this.ForeColor), this.ClientRectangle, sf);
                }

            }
        }
    }
}
