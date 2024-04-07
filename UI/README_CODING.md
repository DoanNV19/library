## 1 Cấu trúc dự án

    src/
    ├─ app/
    │  ├─ modules/
    │  │  ├─ home/
    │  │  │  ├─ [+] components/
    │  │  │  ├─ [+] pages/
    │  │  │  ├─ [+] services/
    │  │  │  ├─ home-routing.module.ts
    │  │  │  ├─ home.module.ts
    │  │  ├─ page-routing.module.ts
    │  │  ├─ page.module.ts
    │  ├─ core/
    │  │  ├─ [+] guards/
    │  │  ├─ [+] footer/
    │  │  ├─ [+] authentication/
    │  │  ├─ [+] http/
    │  │  ├─ [+] interceptors/
    │  │  ├─ [+] mocks/
    │  │  ├─ [+] api-services/
    │  │  ├─ [+] header/
    │  │  ├─ core.module.ts
    │  ├─ share/
    │  │  ├─ components/
    │  │  │  ├─ [+] modals/
    │  │  │  ├─ [+] off-canvas/
    │  │  ├─ [+] directives/
    │  │  ├─ [+] pipes/
    │  │  ├─ [+] models/
    │  │  ├─ [+] untils/
    │  │  ├─ [+] const/
    │  │  ├─ [+] services/
    ├─ assets/
    │  ├─ [+] fonts/
    │  ├─ [+] images/
    │  ├─ [+] i18n/
    │  ├─ [+] scss/
    │  ├─ [+] js/
    │  ├─ [+] sounds/
    ├─ environment/
    │  ├─ environment.prod.ts
    │  ├─ environment.ts

### 1.1 CoreModule

    ●	Tạo các service khởi động khi ứng dụng được chạy
    ●	Import CoreModule trong AppModule. Không được import ở các module khác
    ●   các api serive trong api-services nên tạo file riêng theo controller của BE(ví dụ BE có controller Company => company.api.service.ts)

            │  ├─ core/
            │  │  ├─ [+] guards/
            │  │  ├─ [+] footer/
            │  │  ├─ [+] authentication/
            │  │  ├─ [+] http/
            │  │  ├─ [+] interceptors/
            │  │  ├─ [+] mocks/
            │  │  ├─ [+] api-services/
            │  │  ├─ [+] header/
            │  │  ├─ core.module.ts

### 1.2 Shared Module

    ●	Sử dụng SharedModule để khai báo các components, directives … được sử dụng nhiều lần trong dự án
    ●	SharedModule nên hạn chế sử dụng providers. Tránh phụ thuộc

            │  ├─ share/
            │  │  ├─ components/
            │  │  │  ├─ [+] modals/
            │  │  │  ├─ [+] off-canvas/
            │  │  ├─ [+] directives/
            │  │  ├─ [+] pipes/
            │  │  ├─ [+] models/
            │  │  ├─ [+] untils/
            │  │  ├─ [+] const/
            │  │  ├─ [+] services/

### 1.3 Feature Module

    │  ├─ modules/
    │  │  ├─ moduleABC/
    │  │  │  ├─ [+] components/
    │  │  │  ├─ [+] pages/
    │  │  │  ├─ [+] services/
    │  │  │  ├─ moduleABC-routing.module.ts
    │  │  │  ├─ moduleABC.module.ts
    │  │  ├─ page-routing.module.ts
    │  │  ├─ page.module.ts
    ●	Các chức năng trong module là hoàn toàn độc lập, không phụ thuộc vào module khác. Nếu trường hợp sử dụng component từ module khác thì chỉ có thể sử dụng componet từ module share.
    ●	Các tác vụ cần giao tiếp với API thì chỉ hàm gọi phải được gọi từ thư mục api-service. Không viết lại trong service của module để tránh dư thừa.
    ●	Nếu các module cần sử dụng chung service nên để vào shareModule
    ●   Component trong page chỉ là component rỗng để chứa các component con không sử lý logic . Đặt tên với hậu tố là -page vd: component1-page

## 2.0 Typescript Guidelines

### 2.1 Names

    ●	Sử dụng PascalCase khi đặt tên cho Type, Interface
    ●	Không sử dụng “I” cho các interface
    ●	Sử dụng camelCase cho function name
    ●	Sử dụng camelCase khi đặt tên biến

### 2.2 Types

    ●	Không export types/functions trừ khi sử dụng trong nhiều components
    ●	Các type dùng chung nên khai báo trong share

### 2.3 null and undefined

    ●	sử dụng undefined không sử dụng Null

### 2.4 Flags

    ●	hơn 2 boolean có liên quan cần chuyển thành cờ

### 2.5 Strings

    ●	Sử dụng nháy đơn cho chuỗi.

### 2.6 Quy tắc chung

    ●   Extention cần cài đặt eslint + prettier
    ●	Không sử dụng câu lệnh for..in; thay vào đó, hãy sử dụng ts.forEach, ts.forEachKey và ts.forEachValue
    ●	Cố gắng sử dụng ts.forEach, ts.map và ts.filter thay vì vòng lặp khi điều đó không quá bất tiện.
    ●   Độ dài dòng không quá 140 setting theo prettier
    ●   File đặt tên theo kebab-case

### 2.7 Classes(css)

    ●	Sử dụng kebab-case để đặt tiên cho classes
    ●	Hạn chế sử dụng classes local

### 2.8 Constants

    ●   Khai báo trong share module thư mục constants
    ●	Khai báo const khi bến có giá trị không đổi
    ●	Các const sử dụng kiểu đặt tên UPPER_SNAKE_CASE

### 2.9 Import

    Sử dụng theo như eslint

### 2.10 Function

    ●   Không quá 30 dòng
    ●   Không quá 5 tham số
    ●   Chỉ thực hiện một việc duy nhất
    ●   Các lệnh lồng nhau không quá 4 cấp
    ●   Không nên cố comment để giải thích code

## 3.0 Sử dụng common

### 3.1 common popup

Import component

```js
import { CommonModalComponent } from 'src/app/shared/components/modals/common-modal/common-modal.component';
```

sử dụng

```js
import { CommonModalComponent } from 'src/app/shared/components/modals/common-modal/common-modal.component';

const modalRef = this.modalService.open(CommonModalComponent, { size: 'md', centered: true });
modalRef.componentInstance.TextContain = 'Bạn có muốn deactivate cho ngành dịch vụ này không?';
modalRef.componentInstance.ActionFinish = () => {
  //Action finish
};
modalRef.componentInstance.ActionClose = () => {
  //Action close
};
modalRef.componentInstance.HeaderIcon = 'accuracy-icon.svg';
modalRef.componentInstance.TextButton = {
  Confirm: 'Đồng ý',
  Close: 'Hủy'
};
```

    ●   TextContain : Nội dung hiển thị
    ●   ActionFinish : Hành động sau khi comfirm (nếu không có sẽ không hiển thị)
    ●   ActionClose : Hành động sau khi hủy
    ●   HeaderIcon : Icon của popup được lấy trong "src\assets\images\svg"
    ●   TextButton : Text của button nếu text để rỗng("") sẽ không hiển thị button, nếu không có sẽ hiển thị mặc định

### 3.2 common màu

    ●   primary : #FFAB3B
    ●   secondary : #005ED9
    ●   success : #4CAF50
    ●   info : #2196F3
    ●   warning : #FFC84b
    ●   danger : #FF0000
    ●   light : #FFFFFF
    ●   dark : #808080
