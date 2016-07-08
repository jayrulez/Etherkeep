import { LoginMode } from '../common/login-mode';

export class LoginModel
{
	public loginMode: LoginMode;
	public countryCallingCode: string;
	public areaCode: string;
	public subscriberNumber: string;
	public emailAddress: string;
	public password: string;
	public persistent: boolean;
}