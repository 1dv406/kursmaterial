using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekCustomer.Model;
using Resources;

namespace GeekCustomer.Pages.Shared
{
    public partial class _ContactCreateReadUpdate : System.Web.UI.UserControl
    {
        private Service _service;
        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        public int CustomerId { get; set; }

         /// <summary>
         /// Bestämmer om kontaktuppgifterna ska kunna redigeras eller inte.
         ///</summary>
        public bool ReadOnly { get; set; }

        public _ContactCreateReadUpdate()
        {
            // "ReadOnly" default!
            ReadOnly = true;
        }

        public IEnumerable<Contact> ContactListView_GetData()
        {
            return Service.GetContactsByCustomerId(CustomerId);
        }

        protected void ContactListView_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            /// Bestämmer om kontaktuppgifterna ska kunna redigeras eller inte.
            /// Vyn med index 0 är "readonly"; vyn med index 1 är för redigering.
            /// Vyn "readonly" är default.
            if (!ReadOnly)
            {
                var multiView = e.Item.FindControl("ContactMultiView") as MultiView;
                if (multiView != null)
                {
                    multiView.ActiveViewIndex = 1;
                }
            }
        }

        protected void ContactListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var label = e.Item.FindControl("ContactTypeNameLabel") as Label;
            if (label != null)
            {
                // Typomvandlar e.Item.DataItem så att primärnyckelns värde kan hämtas och...
                var contact = (Contact)e.Item.DataItem;

                // ...som sedan kan användas för att hämta ett ("cachat") kontakttypobjekt...
                var contactType = Service.GetContactTypes()
                    .Single(ct => ct.ContactTypeId == contact.ContactTypeId);

                // ...så att en beskrivning av kontaktypen kan presenteras; ex: Arbete: 012-345 67 89
                label.Text = String.Format(label.Text, contactType.Name);
            }
        }

        protected void ContactListView_PreRender(object sender, EventArgs e)
        {
            // Dölj kontroller för ny kontakt om "read only".
            if (ReadOnly)
            {
                ContactListView.InsertItemPosition = InsertItemPosition.None;
            }
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (Page.ModelState.IsValid)
            {
                try
                {
                    contact.CustomerId = CustomerId;
                    Service.SaveContact(contact);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med kunder.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas 
                    // in av en "extension method" i App_Infrastructure/PageExtensions.)
                    // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
                    Page.SetTempData("SuccessMessage", Strings.Action_Contact_Saved);
                    Response.RedirectToRoute("CustomerDetails", new { id = CustomerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    Page.ModelState.AddModelError(String.Empty, Strings.Contact_Inserting_Error);
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int contactId)
        {
            try
            {
                var contact = Service.GetContact(contactId);
                if (contact == null)
                {
                    // Hittade inte kontaktuppgiften.
                    Page.ModelState.AddModelError(String.Empty,
                        String.Format(Strings.Contact_Not_Found, contactId));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);

                    Page.SetTempData("SuccessMessage", Strings.Action_Contact_Saved);
                    Response.RedirectToRoute("CustomerDetails", new { id = contact.CustomerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, Strings.Contact_Updating_Error);
            }
        }
    
        public IEnumerable<ContactType> ContactTypeDropDownList_GetData()
        {
            return Service.GetContactTypes();
        }

    }
}