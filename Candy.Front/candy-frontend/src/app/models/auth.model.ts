export interface UserLogin {
  email: string;
  passwordHash: string; // Assuming API expects passwordHash, adjust if it's 'password'
}

export interface UserRegister {
  username: string;
  email: string;
  passwordHash: string; // Assuming API expects passwordHash
  firstName?: string;
  lastName?: string;
}

export interface AuthResponse {
  token: string;
  // Include other properties returned by the login endpoint if any
}
