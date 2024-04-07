import { DOCUMENT } from '@angular/common';
import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
// Language
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from 'src/app/shared/services/auth.service';
import { TokenStorageService } from 'src/app/shared/services/token-storage.service';
import { ToastService } from 'src/app/toast-service';

import { ChangePassUserComponent } from '../change-pass-user/change-pass-user.component';

//Logout

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent implements OnInit {
  element: any;
  mode: string | undefined;
  @Output() mobileMenuButtonClicked = new EventEmitter();

  flagvalue: any;
  valueset: any;
  countryName: any;
  cookieValue: any;
  userData: any;
  total = 0;
  cart_length: any = 0;

  constructor(
    @Inject(DOCUMENT) private document: any,
    public _cookiesService: CookieService,
    public translate: TranslateService,
    private router: Router,
    private TokenStorageService: TokenStorageService,
    private AuthenticationService: AuthenticationService,
    private modalService: NgbModal,
    // private userApiService: UserApiService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.userData = this.TokenStorageService.getUser();
    this.element = document.documentElement;

    // Cookies wise Language set
    this.cookieValue = this._cookiesService.get('lang');
    const val = this.listLang.filter(x => x.lang === this.cookieValue);
    this.countryName = val.map(element => element.text);
    if (val.length === 0) {
      if (this.flagvalue === undefined) {
        this.valueset = 'assets/images/flags/us.svg';
      }
    } else {
      this.flagvalue = val.map(element => element.flag);
    }
  }

  /**
   * Toggle the menu bar when having mobile screen
   */
  toggleMobileMenu(event: any) {
    event.preventDefault();
    this.mobileMenuButtonClicked.emit();
  }

  /**
   * Fullscreen method
   */
  fullscreen() {
    document.body.classList.toggle('fullscreen-enable');
    if (!document.fullscreenElement && !this.element.mozFullScreenElement && !this.element.webkitFullscreenElement) {
      if (this.element.requestFullscreen) {
        this.element.requestFullscreen();
      } else if (this.element.mozRequestFullScreen) {
        /* Firefox */
        this.element.mozRequestFullScreen();
      } else if (this.element.webkitRequestFullscreen) {
        /* Chrome, Safari and Opera */
        this.element.webkitRequestFullscreen();
      } else if (this.element.msRequestFullscreen) {
        /* IE/Edge */
        this.element.msRequestFullscreen();
      }
    } else {
      if (this.document.exitFullscreen) {
        this.document.exitFullscreen();
      } else if (this.document.mozCancelFullScreen) {
        /* Firefox */
        this.document.mozCancelFullScreen();
      } else if (this.document.webkitExitFullscreen) {
        /* Chrome, Safari and Opera */
        this.document.webkitExitFullscreen();
      } else if (this.document.msExitFullscreen) {
        /* IE/Edge */
        this.document.msExitFullscreen();
      }
    }
  }

  /***
   * Language Listing
   */
  listLang = [
    { text: 'English', flag: 'assets/images/flags/us.svg', lang: 'en' },
    { text: 'Española', flag: 'assets/images/flags/spain.svg', lang: 'es' },
    { text: 'Deutsche', flag: 'assets/images/flags/germany.svg', lang: 'de' },
    { text: 'Italiana', flag: 'assets/images/flags/italy.svg', lang: 'it' },
    { text: 'русский', flag: 'assets/images/flags/russia.svg', lang: 'ru' },
    { text: '中国人', flag: 'assets/images/flags/china.svg', lang: 'ch' },
    { text: 'français', flag: 'assets/images/flags/french.svg', lang: 'fr' },
    { text: 'Arabic', flag: 'assets/images/flags/ar.svg', lang: 'ar' }
  ];

  /**
   * Logout the user
   */
  logout() {
    this.AuthenticationService.logout();
    this.router.navigate(['/account/login']);
  }

  // Delete Item
  deleteItem(event: any, id: any) {
    const price = event.target.closest('.dropdown-item').querySelector('.item_price').innerHTML;
    const Total_price = this.total - price;
    this.total = Total_price;
    this.cart_length = this.cart_length - 1;
    this.total > 1
      ? ((document.getElementById('empty-cart') as HTMLElement).style.display = 'none')
      : ((document.getElementById('empty-cart') as HTMLElement).style.display = 'block');
    document.getElementById('item_' + id)?.remove();
  }

  /**
   * Search Close Btn
   */
  closeBtn() {
    const searchOptions = document.getElementById('search-close-options') as HTMLAreaElement;
    const dropdown = document.getElementById('search-dropdown') as HTMLAreaElement;
    const searchInputReponsive = document.getElementById('search-options') as HTMLInputElement;
    dropdown.classList.remove('show');
    searchOptions.classList.add('d-none');
    searchInputReponsive.value = '';
  }

  changePassword() {
    const modalRef = this.modalService.open(ChangePassUserComponent, { size: 'md', centered: true });
    modalRef.componentInstance.TextContain = 'Thay đổi mật khẩu';
    modalRef.componentInstance.ActionFinish = (data: any) => {
      // this.userApiService.changeCurrentUserPass(data).subscribe((data: any) => {
      //   if (!data.errorCode) {
      //     modalRef.close();
      //     this.toastService.showSuccess('Đổi mật khẩu thành công!');
      //   } else {
      //     this.toastService.showError(data.errorMessage);
      //   }
      // });
    };
    modalRef.componentInstance.ActionClose = () => {
      modalRef.close();
    };
    modalRef.componentInstance.HeaderIcon = 'comfirm-icon.svg';
    modalRef.componentInstance.TextButton = {
      Confirm: 'Đồng ý',
      Close: 'Hủy'
    };
  }
}
