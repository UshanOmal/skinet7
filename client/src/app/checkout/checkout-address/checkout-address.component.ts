import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AcountService } from 'src/app/account/acount.service';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss'],
})
export class CheckoutAddressComponent {
  @Input() checkoutForm?: FormGroup;

  constructor(
    private accountService: AcountService,
    private toastr: ToastrService
  ) {}

  saveUserAddress() {
    this.accountService
      .updateUserAddress(this.checkoutForm?.get('addressForm')?.value)
      .subscribe({
        next: () => {
          this.toastr.success('Address saved');
          this.checkoutForm?.get('addressForm')?.reset(this.checkoutForm?.get('addressForm')?.value);
      }
      });
  }
}
