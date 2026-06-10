export interface JwtResponse {
  accessToken: string;
  refreshToken: string;
  expires_at: Date;
}