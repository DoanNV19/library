export const email_regex = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/;
export const phone_number_regex = /^(84|0[1-9])+([0-9]{8,9})$/;
export const phone_number_regex_payment = /^([+-]{0,1}[ ]{0,1}[(]{0,1}[0-9]{9,15}[)]{0,1}[ ]{0,1}){0,4}$/
export const notSpace_regex = /^[^\s\t]+$/;
export const taxCode_regex = /^[0-9a-zA-Z\-]{10}(-[0-9]{3})*$/;
export const float_number = /^[+-]?\d+(\.\d+)?$/;

export const passwordRegex = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W)(?!.* ).{1,100}$/;
