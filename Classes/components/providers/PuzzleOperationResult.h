/****************************************************************************
 Copyright (c) 2017-2018 Xiamen Yaji Software Co., Ltd.
 
 http://www.cocos2d-x.org
 
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
 ****************************************************************************/

#ifndef __PUZZLE_OPERATION_RESULT_H__
#define __PUZZLE_OPERATION_RESULT_H__

#include "cocos2d.h"

//
// Types of result: 
// 1) ChooseFirst		- User is choosing the first character of the pair
// 2) NotMatch   		- The current char and the previous chosen one is not matching
// 3) MatchButBlocked	- The current char and the previous chosen one is matching, but the connection is blocked by other characters
// 4) Match				- Match, should return a connection
//

enum PuzzleOperationResultType {

	PuzzleOperationResultType_ChooseFirst = 1,
	PuzzleOperationResultType_NotMatch = 2,
	PuzzleOperationResultType_MatchButBlocked = 3,
	PuzzleOperationResultType_Match = 4
};

class PuzzleOperationResult : public cocos2d::Ref
{
private:

	PuzzleOperationResultType resultType;

public:

	PuzzleOperationResult(PuzzleOperationResultType type);

	PuzzleOperationResultType GetResultType();

};

class PuzzleOperationNotMatchResult : public PuzzleOperationResult
{

public:

	PuzzleOperationNotMatchResult();

};

class PuzzleOperationBlockedResult : public PuzzleOperationResult
{

public:

	PuzzleOperationBlockedResult();

};

class PuzzleOperationMatchResult : public PuzzleOperationResult
{

public:

	PuzzleOperationMatchResult();

};






#endif // __PUZZLE_OPERATION_RESULT_H__
