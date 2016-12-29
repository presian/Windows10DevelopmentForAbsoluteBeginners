﻿using System;

namespace _45_AdeptlyAdaptiveChallenge.DataModels
{
    public class ApplicationState
    {
        public event EventHandler StateUpdate;
        private string currentPageTitle;
        private bool showBackButton;

        public ApplicationState()
        {
            this.CurrentPageTitle = "Financial";
            this.ShowBackButton = false;
        }

        public string CurrentPageTitle
        {
            get
            {
                return this.currentPageTitle;
            }
            set
            {
                this.currentPageTitle = value;
                this.ChangeState();
            }
        }

        public bool ShowBackButton
        {
            get
            {
                return this.showBackButton;
            }
            set
            {
                this.showBackButton = value;
                this.ChangeState();
            }
        }

        public void ChangeState()
        {
            StateUpdate?.Invoke(this, new EventArgs());
        }
    }
}