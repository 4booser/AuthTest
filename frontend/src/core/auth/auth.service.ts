import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'https://localhost:5092/api';

  register(): Observable<> {
    return this.http.get<>(`${this.apiUrl}/auth/register`);
  }
}