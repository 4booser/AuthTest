import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { RegisterRequest } from '../../models/register-request';

import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})

export class Register {
  protected readonly form = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(6)]
    }),
    confirmPassword: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required]
    })
  });

  protected submit(): void {
    const formValue = this.form.getRawValue();

    if (formValue.password !== formValue.confirmPassword) {
      console.log('Passwords do not match');
      return;
    }

    const request: RegisterRequest = {
      email: formValue.email,
      password: formValue.password,
      confirmPassword: formValue.confirmPassword
    };

    console.log('Register request:', request);
  }
}