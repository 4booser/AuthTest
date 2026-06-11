import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { RegisterRequest } from '../../models/register-request';
import { AuthApiService } from '../../services/auth-api.service';

import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterForm } from '../../models/register-form';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})

export class Register {
  private readonly authApi = inject(AuthApiService);

  protected readonly isLoading = signal(false);

  protected readonly form = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required, 
        Validators.minLength(8),
        Validators.maxLength(20),
        Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$/),

      ]
    }),
    confirmPassword: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required]
    })
  });

  protected submit(): void {
    this.form.markAllAsTouched();

    if (this.form.invalid) {
      return;
    }
    const formValue = this.form.getRawValue();

    if (formValue.password !== formValue.confirmPassword) {
      console.log('Passwords do not match');
      return;
    }

    const form: RegisterForm = {
      email: formValue.email,
      password: formValue.password,
      confirmPassword: formValue.confirmPassword
    };

    const request: RegisterRequest = {
      email: form.email,
      password: form.password
    };

    this.isLoading.set(true);

    this.authApi.register(request).subscribe({
      next: () => {
        console.log('Register success');
        this.isLoading.set(false);
      },
      error: error => {
        console.error('Register error:', error);
        this.isLoading.set(false);
      }
    });
  }
}