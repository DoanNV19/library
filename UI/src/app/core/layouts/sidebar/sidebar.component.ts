import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MENU } from 'src/app/shared/constants/menu';
import { MenuItem } from 'src/app/shared/models/menu.model';
import { AppService } from 'src/app/shared/services/app.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  menu: any;
  toggle: any = true;
  menuItems: MenuItem[] = [];
  @ViewChild('sideMenu') sideMenu!: ElementRef;
  @Output() mobileMenuButtonClicked = new EventEmitter();

  constructor(
    private router: Router,
    public translate: TranslateService,
    public appService: AppService
  ) {
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
    // Menu Items
    const listMenuConfig: MenuItem[] = JSON.parse(JSON.stringify(MENU));
    const listRole = this.appService.lstRole;
    this.menuItems = listMenuConfig.filter(x => listRole.includes(x.role ?? '') || !x.role);
    this.menuItems.forEach(x => {
      x.subItems = x.subItems?.filter((item: any) => listRole.includes(item.role ?? '') || !item.role);
    });
    this.menuItems = this.menuItems.filter(x => x.link || x.subItems?.length);
  }

  /***
   * Activate droup down set
   */
  ngAfterViewInit() {
    this.initActiveMenu();
  }

  removeActivation(items: any) {
    items.forEach((item: any) => {
      if (item.classList.contains('menu-link')) {
        if (!item.classList.contains('active')) {
          item.setAttribute('aria-expanded', false);
        }
        item.nextElementSibling ? item.nextElementSibling.classList.remove('show') : null;
      }
      if (item.classList.contains('nav-link')) {
        if (item.nextElementSibling) {
          item.nextElementSibling.classList.remove('show');
        }
        item.setAttribute('aria-expanded', false);
      }
      item.classList.remove('active');
    });
  }

  toggleSubItem(event: any) {
    const isCurrentMenuId = event.target.closest('a.nav-link');
    const dropDowns = Array.from(document.querySelectorAll('.sub-menu'));
    dropDowns.forEach((node: any) => {
      node.classList.remove('show');
    });

    const subDropDowns = Array.from(document.querySelectorAll('.menu-dropdown .nav-link'));
    subDropDowns.forEach((submenu: any) => {
      submenu.setAttribute('aria-expanded', 'false');
    });

    if (event.target && event.target.nextElementSibling) {
      isCurrentMenuId.setAttribute('aria-expanded', 'true');
      event.target.nextElementSibling.classList.toggle('show');
    }
  }

  toggleExtraSubItem(event: any) {
    const isCurrentMenuId = event.target.closest('a.nav-link');
    const dropDowns = Array.from(document.querySelectorAll('.extra-sub-menu'));
    dropDowns.forEach((node: any) => {
      node.classList.remove('show');
    });

    const subDropDowns = Array.from(document.querySelectorAll('.menu-dropdown .nav-link'));
    subDropDowns.forEach((submenu: any) => {
      submenu.setAttribute('aria-expanded', 'false');
    });

    if (event.target && event.target.nextElementSibling) {
      isCurrentMenuId.setAttribute('aria-expanded', 'true');
      event.target.nextElementSibling.classList.toggle('show');
    }
  }

  // Click wise Parent active class add
  toggleParentItem(event: any) {
    const isCurrentMenuId = event.target.closest('a.nav-link');
    const dropDowns = Array.from(document.querySelectorAll('#navbar-nav .show'));
    dropDowns.forEach((node: any) => {
      node.classList.remove('show');
    });
    const ul = document.getElementById('navbar-nav');
    if (ul) {
      const iconItems = Array.from(ul.getElementsByTagName('a'));
      const activeIconItems = iconItems.filter((x: any) => x.classList.contains('active'));
      activeIconItems.forEach((item: any) => {
        item.setAttribute('aria-expanded', 'false');
        item.classList.remove('active');
      });
    }
    isCurrentMenuId.setAttribute('aria-expanded', 'true');
    if (isCurrentMenuId) {
      this.activateParentDropdown(isCurrentMenuId);
    }
  }

  toggleItem(event: any) {
    const isCurrentMenuId = event.target.closest('a.nav-link');
    const isMenu = isCurrentMenuId.nextElementSibling as any;
    if (isMenu.classList.contains('show')) {
      isMenu.classList.remove('show');
      isCurrentMenuId.setAttribute('aria-expanded', 'false');
    } else {
      const dropDowns = Array.from(document.querySelectorAll('#navbar-nav .show'));
      dropDowns.forEach((node: any) => {
        node.classList.remove('show');
      });
      isMenu ? isMenu.classList.add('show') : null;
      const ul = document.getElementById('navbar-nav');
      if (ul) {
        const iconItems = Array.from(ul.getElementsByTagName('a'));
        const activeIconItems = iconItems.filter((x: any) => x.classList.contains('active'));
        activeIconItems.forEach((item: any) => {
          item.setAttribute('aria-expanded', 'false');
          item.classList.remove('active');
        });
      }
      const pathName = window.location.pathname;
      if (ul) {
        const items = Array.from(ul.querySelectorAll('a.nav-link'));
        const activeItems = items.filter((x: any) => x.classList.contains('active'));
        this.removeActivation(activeItems);

        const matchingMenuItem = items.find((x: any) => {
          return pathName.includes(x.pathname);
        });
        if (matchingMenuItem) {
          this.activateParentDropdown(matchingMenuItem);
        }
      }
    }
  }

  // remove active items of two-column-menu
  activateParentDropdown(item: any) {
    item.classList.add('active');
    const parentCollapseDiv = item.closest('.collapse.menu-dropdown');

    if (parentCollapseDiv) {
      // to set aria expand true remaining
      parentCollapseDiv.classList.add('show');
      parentCollapseDiv.parentElement.children[0].classList.add('active');
      parentCollapseDiv.parentElement.children[0].setAttribute('aria-expanded', 'true');
      if (parentCollapseDiv.parentElement.closest('.collapse.menu-dropdown')) {
        parentCollapseDiv.parentElement.closest('.collapse').classList.add('show');
        if (parentCollapseDiv.parentElement.closest('.collapse').previousElementSibling)
          parentCollapseDiv.parentElement.closest('.collapse').previousElementSibling.classList.add('active');
        if (parentCollapseDiv.parentElement.closest('.collapse').previousElementSibling.closest('.collapse')) {
          parentCollapseDiv.parentElement.closest('.collapse').previousElementSibling.closest('.collapse').classList.add('show');
          parentCollapseDiv.parentElement
            .closest('.collapse')
            .previousElementSibling.closest('.collapse')
            .previousElementSibling.classList.add('active');
        }
      }
      return false;
    }
    return false;
  }

  updateActive(event: any) {
    const ul = document.getElementById('navbar-nav');
    if (ul) {
      const items = Array.from(ul.querySelectorAll('a.nav-link'));
      this.removeActivation(items);
    }
    this.activateParentDropdown(event.target);
  }

  initActiveMenu() {
    const pathName = window.location.pathname;
    const ul = document.getElementById('navbar-nav');
    if (ul) {
      const items = Array.from(ul.querySelectorAll('a.nav-link'));
      const activeItems = items.filter((x: any) => x.classList.contains('active'));
      this.removeActivation(activeItems);

      const matchingMenuItem = items.find((x: any) => {
        return pathName.includes(x.pathname);
      });
      if (matchingMenuItem) {
        this.activateParentDropdown(matchingMenuItem);
      }
    }
  }

  removeAllActivation() {
    const ul = document.getElementById('navbar-nav');
    if (ul) {
      const items = Array.from(ul.querySelectorAll('a.nav-link'));
      const activeItems = items.filter((x: any) => x.classList.contains('active'));
      this.removeActivation(activeItems);
    }
  }

  /**
   * Returns true or false if given menu item has child or not
   * @param item menuItem
   */
  hasItems(item: MenuItem) {
    return item.subItems !== undefined ? item.subItems.length > 0 : false;
  }

  /**
   * Toggle the menu bar when having mobile screen
   */
  toggleMobileMenu() {
    const sidebarsize = document.documentElement.getAttribute('data-sidebar-size');
    if (sidebarsize == 'sm-hover-active') {
      document.documentElement.setAttribute('data-sidebar-size', 'sm-hover');
    } else {
      document.documentElement.setAttribute('data-sidebar-size', 'sm-hover-active');
    }
  }

  /**
   * SidebarHide modal
   * @param content modal content
   */
  SidebarHide() {
    document.body.classList.remove('vertical-sidebar-enable');
  }
}